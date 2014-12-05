using System;
using System.Reflection;
using SharedClasses.Data.Attributes;

namespace SharedClasses.Data.Models
{
    public static class SpotTypeExtensions
    {
        private static readonly Type _enumType = typeof(SpotType);

        public static string GetDisplayName(this SpotType type)
        {
            MemberInfo[] memInfo = _enumType.GetMember(type.ToString());
            var attribute = memInfo[0].GetCustomAttribute<EnumDisplayNameAttribute>(false);

            string value = null;
            if (attribute != null)
                value = attribute.Value;

            return value;
        }
    }
}