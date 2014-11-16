using System.ComponentModel;
using SharedClasses.Data.Attributes;

namespace SharedClasses.Data.Models
{
    public class Spot
    {
        [Key]
        [FieldName("SPOTID")]
        public int Id { get; set; }

        [DisplayName("Indentificatienummer")]
        public string Number { get; set; }

        [DbIgnore]
        public SpotType Type { get; set; }

        public int LocationId { get; set; }
    }
}