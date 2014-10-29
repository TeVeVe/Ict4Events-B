using System;

namespace SharedClasses.Data.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class KeyAttribute : System.Attribute
    {
        public string FieldName { get; set; }

        public KeyAttribute()
        {
        }

        public KeyAttribute(string fieldName)
        {
            FieldName = fieldName;
        }
    }
}