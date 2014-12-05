using System;
using System.Collections.Generic;

namespace SharedClasses.Detectors.Events
{
    public class TagEventArgs : EventArgs
    {
        public TagEventArgs(string value, string previousValue, IEnumerable<string> values)
        {
            Value = value;
            PreviousValue = previousValue;
            Values = values;
        }

        public string Value { get; set; }
        public string PreviousValue { get; set; }
        public IEnumerable<string> Values { get; set; }
    }
}