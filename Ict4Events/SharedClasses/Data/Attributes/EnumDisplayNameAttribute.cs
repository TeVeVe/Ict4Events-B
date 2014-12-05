using System;

namespace SharedClasses.Data.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class EnumDisplayNameAttribute : Attribute
    {
        public EnumDisplayNameAttribute(string value)
        {
            Value = value;
        }

        public string Value { get; set; }
    }
}