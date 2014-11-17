using System;
using System.Collections.Generic;
using SharedClasses.Data.Attributes;

namespace SharedClasses.Data.Models
{
    [Table("RESERVATION")]
    public class Reservation : DataModel<Reservation>
    {
        [Key]
        [FieldName("RESERVATIONID")]
        public int Id { get; set; }
        public bool PaymentStatus { get; set; }
        public int AmountOfPeople { get; set; }
        [DbIgnore]
        public IEnumerable<Visitor> Wristbands { get; set; }
        [DbIgnore]
        [ForeignKey("ReserveeId")]
        public Reservee Reservee { get; set; }
        [DbIgnore]
        public IEnumerable<Spot> Spots { get; set; } 
    }
}