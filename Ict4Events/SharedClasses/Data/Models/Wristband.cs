using System;
using SharedClasses.Data.Attributes;

namespace SharedClasses.Data.Models
{
    [Table("WRISTBAND")]
    public class Wristband : DataModel<Wristband>
    {
        [Key]
        public string VisitorCode { get; set; }
        public int ReservationId { get; set; }
        public bool IsOnSite { get; set; }
        [DbIgnore]
        public UserAccount UserAccount { get; set; }
    }
}