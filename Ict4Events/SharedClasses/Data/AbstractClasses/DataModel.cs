using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using SharedClasses.Data.Attributes;

namespace SharedClasses.Data.AbstractClasses
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

        public static IEnumerable<PropertyInfo> GetKeyProperties<T>() where T : DataModel
        {
            return typeof(T)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(prop => prop.GetCustomAttributes<KeyAttribute>(true).Any());
        }

        public static IEnumerable<string> GetFieldNames<T>() where T : DataModel
        {
            return
                typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Except(
                        typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                            .Where(prop => prop.GetCustomAttributes<DbIgnoreAttribute>().Any())).Select(prop =>
                            {
                                var attr = prop.GetCustomAttribute<FieldNameAttribute>();
                                if (attr != null)
                                    return attr.Value;
                                return prop.Name;
                            });
        }
    }

    public abstract class DataModel<T> : DataModel where T : DataModel
    {
        public static IEnumerable<T> Select(Expression<Func<T, bool>> selector)
        {
            if (Database == null) throw new DataException("Database of database was not set.");
            var query = new StringBuilder();
            query.Append("SELECT ");
            query.Append(GetFieldNames<T>().Aggregate((s1, s2) => s1 + ", " + s2));
            query.Append(" FROM ");
            query.Append(GetTableName<T>());

            

            using (var cmd = new OracleCommand(query.ToString(), Database.Connection))
            using (OracleDataReader reader = cmd.ExecuteReader())
            {
                var sb = new StringBuilder();
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        sb.Append(reader[i]);
                        if (i + 1 < reader.FieldCount)
                            sb.Append(", ");
                    }
                    sb.AppendLine();
                }
                Debug.WriteLine(sb.ToString());
            }

            return Enumerable.Empty<T>();
        }
    }
}