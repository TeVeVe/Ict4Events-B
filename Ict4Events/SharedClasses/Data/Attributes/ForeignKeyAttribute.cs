using System;

namespace SharedClasses.Data.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ForeignKeyAttribute : System.Attribute
    {
        public Type TargetType { get; set; }
        public string PropertyName { get; set; }

        public ForeignKeyAttribute(string propertyName)
        {
            PropertyName = propertyName; 
        }
    }
}