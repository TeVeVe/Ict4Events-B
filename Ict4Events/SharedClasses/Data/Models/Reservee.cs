using System.ComponentModel;
using SharedClasses.Data.Attributes;

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
        [DisplayName("Voornaam")]
        [Browsable(false)]
        public string FirstName { get; set; }
        [DisplayName("Tussenvoegsel")]
        [Browsable(false)]
        public string Insertion { get; set; }
        [DisplayName("Achternaam")]
        [Browsable(false)]
        public string LastName { get; set; }

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

        [DisplayName("Volledige naam")]
        [DbIgnore]
        public string FullName
        {
            get
            {
                return FirstName + (!string.IsNullOrEmpty(Insertion) ? ' ' + Insertion + ' ' : " ") + LastName;
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