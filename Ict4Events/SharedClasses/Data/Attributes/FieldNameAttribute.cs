using System;

namespace SharedClasses.Data.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FieldNameAttribute : System.Attribute
    {
        public FieldNameAttribute(string value)
        {
            Value = value;
        }

        public string Value { get; set; }
    }
}