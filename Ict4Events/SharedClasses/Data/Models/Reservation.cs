using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using SharedClasses.Data.Attributes;
using SharedClasses.Extensions;

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
        public Event Event
        {
            get { return Event.Select("EVENTID = " + EventId.ToSqlFormat()).FirstOrDefault(); }
        }

        [DbIgnore]
        [Browsable(false)]
        public IEnumerable<Spot> Spots
        {
            get { return Spot.Select("LOCATIONID = " + Event.LocationId); }
        }

        [DbIgnore]
        [Browsable(false)]
        public IEnumerable<ReservationSpot> ReservationSpots
        {
            get { return ReservationSpot.Select("RESERVATIONID = " + Id.ToSqlFormat()); }
        }
    }
}