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

        public static string GetFieldName<T>(string propertyName)
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
        public static IEnumerable<T> Select(Expression<Func<T, bool>> selector)
        {
            if (Database == null) throw new DataException("Database of database was not set.");
            var query = new StringBuilder();

            var fields = GetFieldNames<T>();

            // Building SELECT..
            query.Append("SELECT ");
            query.Append(fields.Select(pair => pair.Value).Aggregate((s1, s2) => s1 + ", " + s2));

            // Building FROM..
            query.Append(" FROM ");
            query.Append(GetTableName<T>());

            // Building WHERE..
            query.Append(" WHERE ");

            

            var check = (BinaryExpression)selector.Body;
            var checkProperty = ((MemberExpression)check.Left).Member.Name;
            var checkValue = (Expression.Lambda<Func<int>>(check.Right).Compile()());

            query.Append(checkProperty);
            
            // Define operator.
            switch (check.NodeType)
            {
                case ExpressionType.Equal:
                    query.Append("=");
                    break;
                case ExpressionType.GreaterThan:
                    query.Append(">");
                    break;
                case ExpressionType.GreaterThanOrEqual:
                    query.Append(">=");
                    break;
                case ExpressionType.LessThan:
                    query.Append("<");
                    break;
                case ExpressionType.LessThanOrEqual:
                    query.Append("<=");
                    break;
            }

            if (checkValue is string)
                query.Append("\'" + checkValue + "\'");
            else if (checkValue.GetType().IsValueType)
                query.Append(checkValue);


            // Store record data in objects.
            using (var cmd = new OracleCommand(query.ToString(), Database.Connection))
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