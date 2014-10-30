using System;

namespace SharedClasses.Extensions
{
    public static class TypeExtensions
    {
        /// <summary>
        /// Returns the default value of the supplied <see cref="Type"/>.
        /// </summary>
        /// <param name="type"><see cref="Type"/> to return the default value of.</param>
        /// <returns>Default value of the supplied <see cref="Type"/></returns>
        public static object GetDefaultValue(this Type type)
        {
            if (type.IsValueType)
                return Activator.CreateInstance(type);
            return null;
        }
    }
}