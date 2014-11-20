using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using SharedClasses.Data.Attributes;
using SharedClasses.Extensions;

namespace SharedClasses.Data.Models
{
    [Table("EVENT")]
    public class Event : DataModel<Event>
    {
        [Key]
        [FieldName("EVENTID")]
        public int Id { get; set; }

        [System.ComponentModel.DisplayName("Naam")]
        public string Name { get; set; }

        [System.ComponentModel.DisplayName("Huisadres")]
        [DbIgnore]
        public string HomeAddress
        {
            get { return Street + (!string.IsNullOrEmpty(HouseNumber) ? ' ' + HouseNumber : ""); }
        }

        [System.ComponentModel.DisplayName("Straat")]
        [Browsable(false)]
        public string Street { get; set; }
        [System.ComponentModel.DisplayName("Huisnummer")]
        [Browsable(false)]
        public string HouseNumber { get; set; }
        [System.ComponentModel.DisplayName("Postcode")]
        public string PostalCode { get; set; }
        [System.ComponentModel.DisplayName("Begindatum")]
        public DateTime StartDate { get; set; }
        [System.ComponentModel.DisplayName("Einddatum")]
        public DateTime EndDate { get; set; }

        [System.ComponentModel.DisplayName("Plaats")]
        public string City { get; set; }

        [Browsable(false)]
        public int LocationId { get; set; }

        [System.ComponentModel.DisplayName("Max aantal personen")]
        public int MaxGuests { get; set; }

        [DbIgnore]
        [Browsable(false)]
        public IEnumerable<Spot> Spots
        {
            get { return Spot.Select("LOCATIONID = " + LocationId.ToSqlFormat()); }
        }
    }
}