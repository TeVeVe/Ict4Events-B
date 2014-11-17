using System.ComponentModel;
using System.Linq;
using SharedClasses.Data.Attributes;
using SharedClasses.Extensions;

namespace SharedClasses.Data.Models
{
    [Table("RESERVEE")]
    public class Reservee : DataModel<Reservee>
    {
        [Key]
        [DisplayName("Id")]
        public int ReserveeId { get; set; }
        [DisplayName("Email")]
        public string EmailAddress { get; set; }

        [DisplayName("Huisnummer")]
        [Browsable(false)]
        public string HouseNumber { get; set; }

        [DisplayName("Plaats")]
        public string City { get; set; }

        [DisplayName("Postcode")]
        public string PostalCode { get; set; }
        [DisplayName("Straat")]
        [Browsable(false)]
        public string Street { get; set; }

        [Browsable(false)]
        public string VisitorCode { get; set; }

        [DisplayName("Volledige naam")]
        [DbIgnore]
        public string FullName
        {
            get
            {
                var visitor = Visitor.Select("VISITORCODE = " + VisitorCode.ToSqlFormat()).FirstOrDefault();
                return visitor.FirstName + (!string.IsNullOrEmpty(visitor.Insertion) ? ' ' + visitor.Insertion + ' ' : " ") + visitor.LastName;
            }
        }

        [DisplayName("Huisadres")]
        [DbIgnore]
        public string HomeAddress
        {
            get { return Street + (!string.IsNullOrEmpty(HouseNumber) ? ' ' + HouseNumber : ""); }
        }
    }
}