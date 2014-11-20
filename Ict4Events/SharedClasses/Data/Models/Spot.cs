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

        [DbIgnore]
        public SpotType Type { get; set; }

        public int LocationId { get; set; }

        public double LocX { get; set; }
        public double LocY { get; set; }
    }
}