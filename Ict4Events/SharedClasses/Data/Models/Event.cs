using System;
using SharedClasses.Data.Attributes;

namespace SharedClasses.Data.Models
{
    [Table("EVENT")]
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        public DateTime EndDate { get; set; }
        public int MaxGuests { get; set; }
        public String Name { get; set; }
        public DateTime StartDate { get; set; }
        public Location Location { get; set; }

        public int GetVisitorsInside()
        {
            throw new NotImplementedException();
        }
    }
}
