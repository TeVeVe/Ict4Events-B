using System;
using System.Collections.Generic;
using SharedClasses.Data.Attributes;

namespace SharedClasses.Data.Models
{
    public class Reservation : DataModel<Reservation>
    {
        [Key]
        [FieldName("RESERVATIONID")]
        public int Id { get; set; }
        public bool PaymentStatus { get; set; }
        public int AmountOfPeople { get; set; }
        [DbIgnore]
        public IEnumerable<Wristband> Wristbands { get; set; }
        [ForeignKey("ReserveeId")]
        public Reservee Reservee { get; set; }
        [DbIgnore]
        public IEnumerable<Spot> Spots { get; set; } 
    }
}