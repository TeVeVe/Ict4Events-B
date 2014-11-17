using System;
using System.ComponentModel;
using SharedClasses.Data.Attributes;

namespace SharedClasses.Data.Models
{
    [Table("EVENT")]
    public class Event : DataModel<Event>
    {
        [Key]
        [FieldName("EVENTID")]
        public int Id { get; set; }

        [DisplayName("Naam")]
        public string Name { get; set; }

        [DisplayName("Huisadres")]
        [DbIgnore]
        public string HomeAddress
        {
            get { return Street + (!string.IsNullOrEmpty(HouseNumber) ? ' ' + HouseNumber : ""); }
        }

        [DisplayName("Straat")]
        [Browsable(false)]
        public string Street { get; set; }
        [DisplayName("Huisnummer")]
        [Browsable(false)]
        public string HouseNumber { get; set; }
        [DisplayName("Postcode")]
        public string PostalCode { get; set; }
        [DisplayName("Begindatum")]
        public DateTime StartDate { get; set; }
        [DisplayName("Einddatum")]
        public DateTime EndDate { get; set; }

        [DisplayName("Plaats")]
        public string City { get; set; }

        [Browsable(false)]
        public int LocationId { get; set; }

        [DisplayName("Max aantal personen")]
        public int MaxGuests { get; set; }
    }
}