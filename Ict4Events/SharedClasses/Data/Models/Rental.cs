using System;
using System.ComponentModel;
using SharedClasses.Data.Attributes;

namespace SharedClasses.Data.Models
{
    [Table("RENTAL")]
    public class Rental : DataModel<Rental>
    {
        [Key]
        [FieldName("RENTALID")]
        public int Id { get; set; }

        public string VisitorCode { get; set; }
        [DbIgnore]
        [Browsable(false)]
        public TimeSpan RentalLength { get; set; }

        [System.ComponentModel.DisplayName("Is betaald")]
        public bool IsPaid { get; set; }

        [System.ComponentModel.DisplayName("Ingangsdatum")]
        public DateTime StartTime { get; set; }

        public int ProductId { get; set; }
    }
}