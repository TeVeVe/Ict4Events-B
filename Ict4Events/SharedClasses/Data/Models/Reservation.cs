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
        public IEnumerable<Visitor> Visitors { get; set; }

        [Browsable(false)]
        public int ReserveeId { get; set; }

        [Browsable(false)]
        public int EventId { get; set; }

        [DbIgnore]
        [Browsable(false)]
        public IEnumerable<Spot> Spots { get; set; }
    }
}