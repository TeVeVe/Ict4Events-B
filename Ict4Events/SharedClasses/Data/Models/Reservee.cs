using SharedClasses.Data.Attributes;

namespace SharedClasses.Data.Models
{
    [Table("RESERVEE")]
    public class Reservee : DataModel<Reservee>
    {
        [Key]
        //[FieldName("RESERVEEID")]
        public int ReserveeId { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string Insertion { get; set; }
        public string LastName { get; set; }

        public string HouseNumber { get; set; }

        public string City { get; set; }


        public string PostalCode { get; set; }
        public string Street { get; set; }

        //public string FullName
        //{
        //    get { return FirstName + Insertion + LastName; }
        //}

  
    }
}