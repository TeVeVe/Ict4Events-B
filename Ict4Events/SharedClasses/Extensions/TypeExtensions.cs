using System;
using System.Collections.Generic;

namespace SharedClasses.Extensions
{
    public static class TypeExtensions
    {
        private static readonly HashSet<Type> _numericTypes = new HashSet<Type>
        {
            typeof(float),
            typeof(double),
            typeof(decimal),
            typeof(byte),
            typeof(sbyte),
            typeof(ushort),
            typeof(short),
            typeof(uint),
            typeof(int),
            typeof(long),
            typeof(ulong)
        };

        private static readonly HashSet<Type> _floatingPointNumberTypes = new HashSet<Type>
        {
            typeof(float),
            typeof(decimal),
            typeof(double)
        };

        private static readonly HashSet<Type> _wholeNumberTypes = new HashSet<Type>
        {
            typeof(byte),
            typeof(sbyte),
            typeof(ushort),
            typeof(short),
            typeof(uint),
            typeof(int),
            typeof(long),
            typeof(ulong)
        };

        /// <summary>
        ///     Returns the default value of the supplied <see cref="Type" />.
        /// </summary>
        /// <param name="type"><see cref="Type" /> to return the default value of.</param>
        /// <returns>Default value of the supplied <see cref="Type" /></returns>
        public static object GetDefaultValue(this Type type)
        {
            if (type.IsValueType)
                return Activator.CreateInstance(type);
            return null;
        }

        public static bool IsNumericType(this Type type)
        {
            return _numericTypes.Contains(type);
        }

        public static bool IsFloatingPointType(this Type type)
        {
            return _floatingPointNumberTypes.Contains(type);
        }

        public static bool IsWholeNumberType(this Type type)
        {
            return _wholeNumberTypes.Contains(type);
        }
    }
}