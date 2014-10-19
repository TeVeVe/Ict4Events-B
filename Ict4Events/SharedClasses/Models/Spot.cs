namespace SharedClasses.Models
{
    public class Spot
    {
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