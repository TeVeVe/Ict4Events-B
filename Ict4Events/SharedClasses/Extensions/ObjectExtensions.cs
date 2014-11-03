using System;
using System.Globalization;

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
            Type type = obj.GetType();
            if (!typeof(IConvertible).IsAssignableFrom(type))
                return "NULL";
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