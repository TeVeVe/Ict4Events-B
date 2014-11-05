using System;
using SharedClasses.Data.Attributes;

namespace SharedClasses.Data.Models
{
    public class Wristband
    {
        [Key]
        [FieldName("WRISTBANDID")]
        public string VisitorCode { get; set; }
        [DbIgnore]
        public UserAccount UserAccount { get; set; }
    }
}