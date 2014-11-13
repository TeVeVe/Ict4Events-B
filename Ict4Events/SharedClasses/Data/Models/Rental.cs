﻿using System;
using SharedClasses.Data.Attributes;

namespace SharedClasses.Data.Models
{
    public class Rental : DataModel<Rental>
    {
        [Key]
        [FieldName("RENTALID")]
        public int Id { get; set; }
        [ForeignKey("VISITORCODE")]
        public Visitor VisitorCode { get; set; }
        public TimeSpan RentalLength { get; set; }
        public bool IsPaid { get; set; }
        public DateTime StartTime { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public void GetFine()
        {
            throw new NotImplementedException();
        }
    }
}