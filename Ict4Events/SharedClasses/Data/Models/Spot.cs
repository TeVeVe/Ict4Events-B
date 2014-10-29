using SharedClasses.Data.Attributes;

namespace SharedClasses.Data.Models
{
    public class Spot
    {
        [Key]
        [FieldName("SPOT")]
        public int Id { get; set; } 
        public string Number { get; set; }
        public SpotType Type { get; set; }
        public Location Location { get; set; }

        public Spot(string number, SpotType type)
        {
            Number = number;
            Type = type;
        }
    }
}