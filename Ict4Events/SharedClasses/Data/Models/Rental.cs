using System;
using System.ComponentModel;
using System.Linq;
using SharedClasses.Data.Attributes;
using SharedClasses.Extensions;

namespace SharedClasses.Data.Models
{
    [Table("RENTAL")]
    public class Rental : DataModel<Rental>
    {
        [Key]
        [FieldName("RENTALID")]
        public int Id { get; set; }
        [Browsable(false)]
        public string VisitorCode { get; set; }
        [DbIgnore]
        [Browsable(false)]
        public TimeSpan RentalLength { get; set; }

        [DisplayName("Productnaam")]
        [DbIgnore]
        public string ProductName
        {
            get
            {
                var product = Product.Select("PRODUCTID = " + ProductId.ToSqlFormat()).FirstOrDefault();
                return product.Name;
            }
        }

        [DisplayName("Aantal")]
        public int Amount { get; set; }

        [DisplayName("Is betaald")]
        public bool IsPaid { get; set; }

        [DisplayName("Ingangsdatum")]
        public DateTime StartTime { get; set; }

        [Browsable(false)]
        public int ProductId { get; set; }
    }
}