using System;
using System.Collections.Generic;
using SharedClasses.Data.Attributes;

namespace SharedClasses.Data.Models
{
    public class Reservation
    {
        [Key]
        [FieldName("RESERVATION")]
        public int Id { get; set; }
        public bool PaymentStatus { get; set; }
        public IEnumerable<Wristband> Wristbands { get; set; }
        public Reservee Reservee { get; set; }
        public IEnumerable<Spot> Spots { get; set; } 

        public Reservation(Reservee reservee, int amount)
        {
            Reservee = reservee;

            // TODO: Implement wristband creation based on param "amount".
            throw new NotImplementedException();
        }
    }
}