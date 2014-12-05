using System;

namespace SharedClasses.Data.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ForeignKeyAttribute : Attribute
    {
        // When the PropertyName is the same as the TargetPropertyName
        public ForeignKeyAttribute(string propertyName)
        {
            PropertyName = propertyName;
            TargetPropertyName = propertyName;
        }

        // When the PropertyName is not the same as the TargetPropertyName
        public ForeignKeyAttribute(string propertyName, string targetPropertyName)
        {
            PropertyName = propertyName;
            TargetPropertyName = targetPropertyName;
        }

        public string PropertyName { get; set; }
        public string TargetPropertyName { get; set; }
    }
}