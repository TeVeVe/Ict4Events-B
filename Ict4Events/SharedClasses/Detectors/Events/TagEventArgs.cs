using System;
using System.Collections;
using System.Collections.Generic;

namespace SharedClasses.Detectors.Events
{
    public class TagEventArgs : EventArgs
    {
        public string Value { get; set; }
        public string PreviousValue { get; set; }
        public IEnumerable<string> Values { get; set; }

        public TagEventArgs(string value, string previousValue, IEnumerable<string> values)
        {
            Value = value;
            PreviousValue = previousValue;
            Values = values;
        }
    }
}