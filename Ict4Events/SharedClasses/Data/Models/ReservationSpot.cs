using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharedClasses.Data.Attributes;
using SharedClasses.Extensions;

namespace SharedClasses.Data.Models
{
     [Table("RESERVATIONSPOT")]
    public class ReservationSpot : DataModel<ReservationSpot>
    {
         [Key]
         [FieldName("RESERVATIONID")]
         public int Id { get; set; }

         [FieldName("SPOTID")]
         public int SpotId { get; set; }

         [DbIgnore]
         public Spot Spot
         {
             get { return Spot.Select("SPOTID = " + SpotId.ToSqlFormat()).FirstOrDefault(); }
         }
    }
}
