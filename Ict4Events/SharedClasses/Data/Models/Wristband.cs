using System;
using SharedClasses.Data.Attributes;

namespace SharedClasses.Data.Models
{
    public class Wristband : DataModel<Wristband>
    {
        [Key]
        [FieldName("WRISTBANDID")]
<<<<<<< HEAD
        public int Id { get; set; }
=======
>>>>>>> origin/master
        public string VisitorCode { get; set; }
        [DbIgnore]
        public UserAccount UserAccount { get; set; }
    }
}