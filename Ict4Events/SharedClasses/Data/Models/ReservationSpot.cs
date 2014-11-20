using System.ComponentModel;
using System.Linq;
using SharedClasses.Data.Attributes;
using SharedClasses.Extensions;

namespace SharedClasses.Data.Models
{
    [Table("RESERVATIONSPOT")]
    public class ReservationSpot : DataModel<ReservationSpot>
    {
        [Key]
        [FieldName("RESERVATIONSPOTID")]
        [Browsable(false)]
        public int Id { get; set; }

        [FieldName("SPOTID")]
        [Browsable(false)]
        public int SpotId { get; set; }

        [FieldName("RESERVATIONID")]
        [Browsable(false)]
        public int ReservationId { get; set; }

        [DbIgnore]
        [Browsable(false)]
        public Spot Spot
        {
            get { return Spot.Select("SPOTID = " + SpotId.ToSqlFormat()).FirstOrDefault(); }
        }
    }
}