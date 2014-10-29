﻿using System;
using SharedClasses.Data.Attributes;

namespace SharedClasses.Data.Models
{
    public class Rental
    {
        [Key]
        [FieldName("RENTAL")]
        public int Id { get; set; } 
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