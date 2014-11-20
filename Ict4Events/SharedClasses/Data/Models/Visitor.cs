using System;
using System.ComponentModel;
using SharedClasses.Data.Attributes;

namespace SharedClasses.Data.Models
{
    [Table("VISITOR")]
    public class Visitor : DataModel<Visitor>
    {
        [Key]
        [DisplayName("Id")]
        public string VisitorCode { get; set; }

        [Browsable(false)]
        public int ReservationId { get; set; }

        /// <summary>
        ///     Gets the full name by combining the <see cref="FirstName" />, <see cref="Insertion" /> and <see cref="LastName" />.
        /// </summary>
        [DisplayName("Volledige naam")]
        [DbIgnore]
        public string FullName
        {
            get { return FirstName + (!string.IsNullOrEmpty(Insertion) ? ' ' + Insertion + ' ' : " ") + LastName; }
        }

        [DisplayName("Is aanwezig")]
        public bool IsOnSite { get; set; }

        [DisplayName("Voornaam")]
        [Browsable(false)]
        public string FirstName { get; set; }

        [DisplayName("Tussenvoegsel")]
        [Browsable(false)]
        public string Insertion { get; set; }

        [DisplayName("Achternaam")]
        [Browsable(false)]
        public string LastName { get; set; }

        [DisplayName("Telefoon")]
        [FieldName("PHONENR")]
        public string Phone { get; set; }

        [DisplayName("Geboortedatum")]
        [FieldName("BIRTHDATE")]
        public DateTime BirthDate { get; set; }
    }
}