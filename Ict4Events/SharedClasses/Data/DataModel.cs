using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows;
using Oracle.DataAccess.Client;
using SharedClasses.Data.Attributes;
using SharedClasses.Data.Models.Types;
using SharedClasses.Extensions;

namespace SharedClasses.Data
{
    public abstract class DataModel
    {
        [Flags]
        public enum QueryOptions
        {
            InternetAccess
        }

        private static Database _database;
        public static Database Database
        {
            get { return _database; }
            set
            {
                _database = value;
                if (_database != null)
                    AppDomain.CurrentDomain.ProcessExit += (sender, args) => _database.Dispose();
            }
        }

        /// <summary>
        ///     Gets the table name when specified on the <see cref="Type" />.
        /// </summary>
        /// <returns>Table name of the <see cref="Type" />.</returns>
        public static string GetTableName<T>() where T : DataModel
        {
            return typeof(T).GetCustomAttribute<TableAttribute>().Name;
        }

        public static PropertyInfo GetKeyProperty<T>() where T : DataModel
        {
            return typeof(T)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .FirstOrDefault(prop => prop.GetCustomAttributes<KeyAttribute>(true).Any());
        }

        public static string GetPrimaryKey<T>() where T : DataModel
        {
            PropertyInfo prop = GetKeyProperty<T>();

            var fieldNameAttr = prop.GetCustomAttribute<FieldNameAttribute>(true);
            if (fieldNameAttr != null)
                return fieldNameAttr.Value;
            return prop.Name;
        }

        public static string GetFieldName<T>(string propertyName) where T : DataModel
        {
            PropertyInfo prop = typeof(T).GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
            var attr = prop.GetCustomAttribute<FieldNameAttribute>();
            if (attr != null)
                return attr.Value;
            return prop.Name;
        }

        public static IEnumerable<PropertyInfo> GetKeyProperties<T>() where T : DataModel
        {
            return typeof(T)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(prop => prop.GetCustomAttributes<KeyAttribute>(true).Any());
        }

        public static IEnumerable<KeyValuePair<string, string>> GetFieldNames<T>() where T : DataModel
        {
            return
                typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Except(
                        typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                            .Where(prop => prop.GetCustomAttributes<DbIgnoreAttribute>().Any())).Select(prop =>
                            {
                                var attr = prop.GetCustomAttribute<FieldNameAttribute>();
                                if (attr != null)
                                    return new KeyValuePair<string, string>(prop.Name, attr.Value);
                                return new KeyValuePair<string, string>(prop.Name, prop.Name);
                            });
        }
    }

    public abstract class DataModel<T> : DataModel where T : DataModel, new()
    {
        public static IEnumerable<T> Select(string whereStatement = null, QueryOptions options = 0,
            string ignoreFields = null)
        {
            if (Database == null) throw new DataException("Database of database was not set.");
            IEnumerable<KeyValuePair<string, string>> fields = GetFieldNames<T>();

            // Build select.
            var builder = new StringBuilder();
            builder.Append("SELECT ");
            builder.Append(fields.Select(p => p.Value).Aggregate((s1, s2) => s1 + ", " + s2));
            builder.Append(" FROM ");
            builder.Append(GetTableName<T>());

            if (!string.IsNullOrWhiteSpace(whereStatement))
            {
                builder.Append(" WHERE ");
                builder.Append(whereStatement);
            }

            // Store record data in objects.
            using (var cmd = new OracleCommand(builder.ToString(), Database.Connection))
            using (OracleDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var obj = new T();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        PropertyInfo prop = typeof(T).GetProperty(fields.ElementAt(i).Key);
                        object value = reader[fields.ElementAt(i).Value];


                        if (value is string)
                        {
                            if (((string)value).Length == 1)
                            {
                                // Convert string Y or N to boolean.
                                char val = ((string)value)[0];
                                if (new[]
                                {
                                    'Y', 'N'
                                }.Contains(val))
                                    value = val == 'Y';
                            }

                            // If property is of type Image then we expect a string.
                            if (options.HasFlag(QueryOptions.InternetAccess) && prop.PropertyType == typeof(DbImage))
                            {
                                var val = new Uri((string)value);
                                if (!val.IsLocal())
                                {
                                    using (var client = new WebClient())
                                    using (var imageStream = new MemoryStream(client.DownloadData(val)))
                                        value = Image.FromStream(imageStream);
                                }
                                else
                                    throw new FileLoadException("Local path supplied. Must be remote a remote path.");
                            }
                        }

                        // Convert DBNull to default type value.
                        if (value is DBNull)
                        {
                            if (Nullable.GetUnderlyingType(prop.PropertyType) == null)
                                value = value.GetType().GetDefaultValue();
                        }

                        prop.SetValue(obj, value);
                    }
                    yield return obj;
                }
            }
        }

        /// <summary>
        ///     Updates a record in the database by using the primary key.
        /// </summary>
        /// <returns>A value bigger than zero if succeeded.</returns>
        public int Update()
        {
            if (Database == null) throw new DataException("Database of database was not set.");
            var fields = GetFieldNames<T>().Where(p => p.Value != GetPrimaryKey<T>());

            // Build UPDATE.
            var builder = new StringBuilder();
            builder.Append("UPDATE ");
            builder.Append(GetTableName<T>());
            builder.Append(" SET ");

            // Build SET.
            for (int i = 0; i < fields.Count(); i++)
            {
                KeyValuePair<string, string> setField = fields.ElementAt(i);

                builder.Append(setField.Value);
                builder.Append(" = ");

                PropertyInfo prop = typeof(T).GetProperty(setField.Key, BindingFlags.Public | BindingFlags.Instance);

                // Save field to database.
                builder.Append(prop.GetValue(this).ToSqlFormat());

                if (i < fields.Count() - 1)
                    builder.Append(',');
            }

            builder.Append(" WHERE ");
            builder.Append(GetPrimaryKey<T>());
            builder.Append(" = ");
            builder.Append(GetKeyProperty<T>().GetValue(this));

            // Store record data in objects.
            using (var cmd = new OracleCommand(builder.ToString(), Database.Connection))
                return cmd.ExecuteNonQuery();
        }
    }
}