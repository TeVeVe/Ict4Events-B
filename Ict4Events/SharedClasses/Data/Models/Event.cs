﻿using System;
using SharedClasses.Data.Attributes;

namespace SharedClasses.Data.Models
{
    [Table("EVENT")]
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        public string Name { get; set; }
        public string StreetName { get; set; }
        public string HouseNumber { get; set; }
        public string PostalCode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Location Location { get; set; }
        public int MaxGuests { get; set; }

        public int GetVisitorsInside()
        {
            throw new NotImplementedException();
        }
    }
}
