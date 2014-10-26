using System;

namespace SharedClasses.Data.Models
{
    public class Rental
    {
        public TimeSpan BorrowLength { get; set; }
        public bool IsPaid { get; set; }
        public DateTime StartTime { get; set; }
        public Product Product { get; set; }

        public void GetFine()
        {
            throw new NotImplementedException();
        }
    }
}