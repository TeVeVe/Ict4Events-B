using System;
using System.Globalization;
using SharedClasses.Data.Models.Types;

namespace SharedClasses.Extensions
{
    public static class ObjectExtensions
    {
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
            return '\'' + (string)obj + '\'';
        }
    }
}