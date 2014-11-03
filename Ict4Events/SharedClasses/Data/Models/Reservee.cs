using SharedClasses.Data.Attributes;

namespace SharedClasses.Data.Models
{
    public class Reservee
    {
        [Key]
        [FieldName("RESERVEEID")]
        public int Id { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string Insertion { get; set; }
        public string LastName { get; set; }

        public string HouseNumber { get; set; }
        
        public string PostalCode { get; set; }
        public string Street { get; set; }

        public string FullName
        {
            get { return FirstName + Insertion + LastName; }
        }

        public Reservee(string firstName, string insertion, string lastName, string postalCode, string street, string houseNumber)
        {
            FirstName = firstName;
            Insertion = insertion;
            LastName = lastName;
            PostalCode = postalCode;
            Street = street;
            HouseNumber = houseNumber;
        }
    }
}