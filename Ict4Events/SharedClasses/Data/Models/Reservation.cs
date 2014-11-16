using System.Collections.Generic;
using System.ComponentModel;
using SharedClasses.Data.Attributes;

namespace SharedClasses.Data.Models
{
    [Table("RESERVATION")]
    public class Reservation : DataModel<Reservation>
    {
        [Key]
        [FieldName("RESERVATIONID")]
        public int Id { get; set; }

        [DisplayName("Heeft betaald")]
        public bool PaymentStatus { get; set; }

        [DisplayName("Aantal personen")]
        public int AmountOfPeople { get; set; }

        [DbIgnore]
        [Browsable(false)]
        public IEnumerable<Visitor> Wristbands { get; set; }

        [DbIgnore]
        [ForeignKey("ReserveeId")]
        [Browsable(false)]
        public Reservee Reservee { get; set; }

        [DbIgnore]
        [Browsable(false)]
        public IEnumerable<Spot> Spots { get; set; }
    }
}