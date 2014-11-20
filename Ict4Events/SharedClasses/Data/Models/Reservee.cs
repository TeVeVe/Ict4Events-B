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
        [FieldName("ReserveeId")]
        [DisplayName("Id")]
        public int Id { get; set; }

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

        [FieldName("PHONENR")]
        [DisplayName("Telefoon")]
        public string Phone { get; set; }

        [DisplayName("Volledige naam")]
        [DbIgnore]
        public string FullName
        {
            get
            {
                Visitor visitor = Visitor.Select("VISITORCODE = " + VisitorCode.ToSqlFormat()).FirstOrDefault();
                return visitor.FirstName +
                       (!string.IsNullOrEmpty(visitor.Insertion) ? ' ' + visitor.Insertion + ' ' : " ") +
                       visitor.LastName;
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