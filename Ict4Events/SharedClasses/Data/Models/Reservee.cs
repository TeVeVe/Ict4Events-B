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

        [DisplayName("Volledige naam")]
        [DbIgnore]
        public string FullName
        {
            get { return FirstName + (!string.IsNullOrEmpty(Insertion) ? ' ' + Insertion + ' ' : " ") + LastName; }
        }

        [DisplayName("Voornaam")]
        [FieldName("FIRSTNAME")]
        public string FirstName { get; set; }

        [DisplayName("Tussenvoegsel")]
        [FieldName("INSERTION")]
        public string Insertion { get; set; }

        [DisplayName("Achternaam")]
        [FieldName("LASTNAME")]
        public string LastName { get; set; }

        [DisplayName("Huisadres")]
        [DbIgnore]
        public string HomeAddress
        {
            get { return Street + (!string.IsNullOrEmpty(HouseNumber) ? ' ' + HouseNumber : ""); }
        }

        [DisplayName("Email")]
        public string EmailAddress { get; set; }

        [DisplayName("Huisnummer")]
        [FieldName("HOUSENUMBER")]
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

        [DbIgnore]
        [DisplayName("Telefoon")]
        [FieldName("PHONENR")]
        public string Phone
        {
            get
            {
                Visitor visitor = Visitor.Select("VISITORCODE = " + VisitorCode.ToSqlFormat()).FirstOrDefault();
                if (visitor != null)
                    return visitor.Phone;
                return null;
            }
        }
    }
}