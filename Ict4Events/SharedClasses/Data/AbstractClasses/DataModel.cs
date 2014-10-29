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
using SharedClasses.Data.Models;

namespace SharedClasses.Data.AbstractClasses
{
    public abstract class DataModel
    {
        public static Database Database;

        public PropertyInfo GetKeyProperty()
        {
            return GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .FirstOrDefault(prop => prop.GetCustomAttributes<KeyAttribute>(true).Any());
        }

        public IEnumerable<PropertyInfo> GetKeyProperties()
        {
            return GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(prop => prop.GetCustomAttributes<KeyAttribute>(true).Any());
        }

        /// <summary>
        /// Gets the table name when specified on the <see cref="Type"/>.
        /// </summary>
        /// <returns>Table name of the <see cref="Type"/>.</returns>
        public string GetTableName()
        {
            return GetType().GetCustomAttribute<TableAttribute>().Name;
        }
    }

    public abstract class DataModel<T> : DataModel where T : DataModel
    {

        public static IEnumerable<T> Select(Expression<Func<T, bool>> selector)
        {
            if (Database == null) throw new DataException("Database of database was not set.");
            StringBuilder query = new StringBuilder();
            query.Append("SELECT * FROM");
            query.Append(" PRODUCT");

            BinaryExpression equality = (BinaryExpression)selector.Body;
            Debug.WriteLine(equality.NodeType);

            using (OracleCommand cmd = new OracleCommand(query.ToString(), Database.Connection))
            {
                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    StringBuilder sb = new StringBuilder();
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
            }

            return Enumerable.Empty<T>();
        }
    }
}