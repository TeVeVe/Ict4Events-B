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
        [System.ComponentModel.DisplayName("Id")]
        public int Id { get; set; }
        [System.ComponentModel.DisplayName("Email")]
        public string EmailAddress { get; set; }

        [System.ComponentModel.DisplayName("Huisnummer")]
        [Browsable(false)]
        public string HouseNumber { get; set; }

        [System.ComponentModel.DisplayName("Plaats")]
        public string City { get; set; }

        [System.ComponentModel.DisplayName("Postcode")]
        public string PostalCode { get; set; }
        [System.ComponentModel.DisplayName("Straat")]
        [Browsable(false)]
        public string Street { get; set; }

        [Browsable(false)]
        public string VisitorCode { get; set; }

        [System.ComponentModel.DisplayName("Volledige naam")]
        [DbIgnore]
        public string FullName
        {
            get
            {
                var visitor = Visitor.Select("VISITORCODE = " + VisitorCode.ToSqlFormat()).FirstOrDefault();
                return visitor.FirstName + (!string.IsNullOrEmpty(visitor.Insertion) ? ' ' + visitor.Insertion + ' ' : " ") + visitor.LastName;
            }
        }

        [System.ComponentModel.DisplayName("Huisadres")]
        [DbIgnore]
        public string HomeAddress
        {
            get { return Street + (!string.IsNullOrEmpty(HouseNumber) ? ' ' + HouseNumber : ""); }
        }
    }
}