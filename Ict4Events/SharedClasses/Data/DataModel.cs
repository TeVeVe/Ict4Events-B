using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Reflection;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using SharedClasses.Data.Attributes;
using SharedClasses.Extensions;

namespace SharedClasses.Data
{
    public abstract class DataModel
    {
        public static Database Database;

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

        public static string GetFieldName<T>(string propertyName) where T : DataModel
        {
            var prop = typeof(T).GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
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
        public static IEnumerable<T> Select(string whereStatement, string ignoreFields = null)
        {
            if (Database == null) throw new DataException("Database of database was not set.");
            var fields = GetFieldNames<T>();

            // Build select.
            var builder = new StringBuilder();
            builder.Append("SELECT ");
            builder.Append(fields.Select(p => p.Value).Aggregate((s1, s2) => s1 + ", " + s2));
            builder.Append(" FROM ");
            builder.Append(GetTableName<T>());
            builder.Append(" WHERE ");
            builder.Append(whereStatement);

            // Store record data in objects.
            using (var cmd = new OracleCommand(builder.ToString(), Database.Connection))
            using (OracleDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var obj = new T();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        var prop = typeof(T).GetProperty(fields.ElementAt(i).Key);
                        object value = reader[fields.ElementAt(i).Value];


                        if (value is string)
                        {
                            if (((string)value).Length == 1)
                            {
                                // Convert string Y or N to boolean.
                                char val = ((string)value)[0];
                                if (new[] { 'Y', 'N' }.Contains(val))
                                    value = val == 'Y';
                            }

                            // If property is of type Image then we expect a string.
                            if (prop.PropertyType.GetType() == typeof(Image))
                            {
                                var val = new Uri((string)value);
                                if (!val.IsLocal())
                                {
                                    using (var client = new WebClient())
                                    using (var imageStream = new MemoryStream(client.DownloadData(val)))
                                    {
                                        value = Image.FromStream(imageStream);
                                    }
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

        public static IEnumerable<T> Update(string updateStatement, string ignoreFields = null)
        {
            if (Database == null) throw new DataException("Database of database was not set.");
            var fields = GetFieldNames<T>();

            // Build select.
            var builder = new StringBuilder();
            builder.Append("SELECT ");
            builder.Append(fields.Select(p => p.Value).Where(v => !string.IsNullOrWhiteSpace(ignoreFields) && ignoreFields.IndexOf(v, StringComparison.OrdinalIgnoreCase) < 0).Aggregate((s1, s2) => s1 + ", " + s2));
            builder.Append(" FROM ");
            builder.Append(GetTableName<T>());
            builder.Append(" WHERE ");
            builder.Append(updateStatement);

            // Store record data in objects.
            using (var cmd = new OracleCommand(builder.ToString(), Database.Connection))
            using (OracleDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var obj = new T();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        typeof(T).GetProperty(fields.ElementAt(i).Key).SetValue(obj, reader[fields.ElementAt(i).Value]);
                    }
                    yield return obj;
                }
            }
        }
    }
}