using System.ComponentModel;
using SharedClasses.Data.Attributes;

namespace SharedClasses.Data.Models
{
    [Table("SPOT")]
    public class Spot : DataModel<Spot>
    {
        [Key]
        [FieldName("SPOTID")]
        public int Id { get; set; }

        [FieldName("SPOTNUMBER")]
        [DisplayName("Indentificatienummer")]
        public int Number { get; set; }

        [DbIgnore]
        public SpotType Type { get; set; }

        public int LocationId { get; set; }

        public int LocX { get; set; }
        public int LocY { get; set; }
    }
}