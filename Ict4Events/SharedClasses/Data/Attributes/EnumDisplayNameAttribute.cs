using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedClasses.Data.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class EnumDisplayNameAttribute : Attribute
    {
        public string Value { get; set; }

        public EnumDisplayNameAttribute(string value)
        {
            Value = value;
        }
    }
}
