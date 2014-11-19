using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using SharedClasses.Data.Models.Types;

namespace SharedClasses.Extensions
{
    public static class ObjectExtensions
    {
        private static readonly Dictionary<Type, OracleDbType> OracleDbTypes = new Dictionary<Type, OracleDbType>()
        {
            { typeof(byte), OracleDbType.Byte },
            { typeof(byte[]), OracleDbType.Raw },
            { typeof(char), OracleDbType.Varchar2 },
            { typeof(char[]), OracleDbType.Varchar2 },
            { typeof(DateTime), OracleDbType.TimeStamp },
            { typeof(short), OracleDbType.Int16 },
            { typeof(int), OracleDbType.Int32 },
            { typeof(long), OracleDbType.Int64 },
            { typeof(float), OracleDbType.Single },
            { typeof(double), OracleDbType.Double },
            { typeof(decimal), OracleDbType.Decimal },
            { typeof(string), OracleDbType.Varchar2 },
            { typeof(TimeSpan), OracleDbType.IntervalDS },
            { typeof(OracleBFile), OracleDbType.BFile },
            { typeof(OracleBinary), OracleDbType.Raw },
            { typeof(OracleBlob), OracleDbType.Blob },
            { typeof(OracleClob), OracleDbType.Clob },
            { typeof(OracleDate), OracleDbType.Date },
            { typeof(OracleDecimal), OracleDbType.Decimal },
            { typeof(OracleIntervalDS), OracleDbType.IntervalDS },
            { typeof(OracleIntervalYM), OracleDbType.IntervalYM },
            { typeof(OracleRefCursor), OracleDbType.RefCursor },
            { typeof(OracleString), OracleDbType.Varchar2 },
            { typeof(OracleTimeStamp), OracleDbType.TimeStamp },
            { typeof(OracleTimeStampLTZ), OracleDbType.TimeStampLTZ },
            { typeof(OracleTimeStampTZ), OracleDbType.TimeStampTZ },
            { typeof(OracleXmlType), OracleDbType.XmlType },
            { typeof(OracleRef), OracleDbType.Ref }
        };

        /// <summary>
        ///     Converts the object to a string suitable for SQL statements.
        /// </summary>
        /// <param name="obj">Value to convert to a SQL-friendly string.</param>
        /// <returns>A SQL-friendly representation of the value.</returns>
        public static string ToSqlFormat(this object obj)
        {
            if (obj == null) return "NULL";

            Type type = obj.GetType();
            if (!typeof(IConvertible).IsAssignableFrom(type))
                return "NULL";
            if (typeof(DbImage).IsAssignableFrom(type))
                return '\'' + ((DbImage)obj).Uri.AbsoluteUri + '\'';
            if (type.IsWholeNumberType())
                return ((int)Convert.ChangeType(obj, typeof(int))).ToString(CultureInfo.InvariantCulture);
            if (type.IsFloatingPointType())
                return ((decimal)Convert.ChangeType(obj, typeof(decimal))).ToString(CultureInfo.InvariantCulture);
            if (type == typeof(bool))
                return '\'' + ((bool)obj ? "Y" : "N") + '\'';
            if (type == typeof (DateTime))
                return string.Format("TO_DATE('{0}', 'yyyy-MM-dd hh:mi:ss')", ((DateTime)obj).ToString("yyyy-MM-dd hh:mm:ss")); 
            return '\'' + (string)obj + '\'';
        }

        public static OracleDbType GetOrableDbType(this object obj)
        {
            if (obj == null) return OracleDbType.Object;

            Type type = obj.GetType();
            if (OracleDbTypes.ContainsKey(type))
                return OracleDbTypes[type];
            return OracleDbType.Object;
        }

        /// <summary>
        /// Returns a (possible larger) byte length to store the object.
        /// </summary>
        /// <returns></returns>
        public static int GetByteSize(this object obj)
        {
            using (Stream s = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(s, obj);
                return (int)s.Length;
            }
        }

        public static T ChangeType<T>(this object value, out bool success) where T : class 
        {
            success = false;
            var val = value as T;
            if (val != default(T))
            {
                success = true;
                return val;
            }
            
            return default(T);
        }
    }
}