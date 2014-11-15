using System;
using SharedClasses.Data.Attributes;

namespace SharedClasses.Data.Models
{
    [Table("EVENT")]
    public class Event : DataModel<Event>
    {
        [Key]
        [FieldName("EVENTID")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string PostalCode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string City { get; set; }
        public int LocationId { get; set; }
        public int MaxGuests { get; set; }
    }
}
