using System.ComponentModel;
using SharedClasses.Data.Attributes;

namespace SharedClasses.Data.Models
{
    [Table("VISITOR")]
    public class Visitor : DataModel<Visitor>
    {
        [Key]
        [System.ComponentModel.DisplayName("Id")]
        public string VisitorCode { get; set; }

        [Browsable(false)]
        public int ReservationId { get; set; }

        /// <summary>
        ///     Gets the full name by combining the <see cref="FirstName" />, <see cref="Insertion" /> and <see cref="LastName" />.
        /// </summary>
        [System.ComponentModel.DisplayName("Volledige naam")]
        [DbIgnore]
        public string FullName
        {
            get { return FirstName + (!string.IsNullOrEmpty(Insertion) ? ' ' + Insertion + ' ' : " ") + LastName; }
        }

        [System.ComponentModel.DisplayName("Is aanwezig")]
        public bool IsOnSite { get; set; }

        [System.ComponentModel.DisplayName("Voornaam")]
        [Browsable(false)]
        public string FirstName { get; set; }

        [System.ComponentModel.DisplayName("Tussenvoegsel")]
        [Browsable(false)]
        public string Insertion { get; set; }

        [System.ComponentModel.DisplayName("Achternaam")]
        [Browsable(false)]
        public string LastName { get; set; }
    }
}