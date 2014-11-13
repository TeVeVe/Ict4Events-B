using System;
using SharedClasses.Data.Attributes;

namespace SharedClasses.Data.Models
{
    [Table("VISITOR")]
    public class Visitor : DataModel<Visitor>
    {
        [Key]
        public string VisitorCode { get; set; }
        public int ReservationId { get; set; }
        public bool IsOnSite { get; set; }
        public string FirstName { get; set; }
        public string Insertion { get; set; }
        public string LastName { get; set; }
    }
}