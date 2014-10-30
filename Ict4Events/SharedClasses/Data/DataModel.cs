using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using SharedClasses.Data.Attributes;

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
            builder.Append(fields.Select(p => p.Value).Where(v => !string.IsNullOrWhiteSpace(ignoreFields) && ignoreFields.IndexOf(v, StringComparison.OrdinalIgnoreCase) < 0).Aggregate((s1, s2) => s1 + ", " + s2));
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
                        typeof(T).GetProperty(fields.ElementAt(i).Key).SetValue(obj, reader[fields.ElementAt(i).Value]);
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