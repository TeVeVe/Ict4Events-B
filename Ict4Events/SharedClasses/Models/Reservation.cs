using System;
using System.Collections;
using System.Collections.Generic;

namespace SharedClasses.Models
{
    public class Reservation
    {
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