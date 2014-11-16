﻿using System;
using System.ComponentModel;
using SharedClasses.Data.Attributes;

namespace SharedClasses.Data.Models
{
    public class Rental : DataModel<Rental>
    {
        [Key]
        [FieldName("RENTALID")]
        public int Id { get; set; }

        public string VisitorCode { get; set; }

        public TimeSpan RentalLength { get; set; }

        [DisplayName("Is betaald")]
        public bool IsPaid { get; set; }

        [DisplayName("Ingangsdatum")]
        public DateTime StartTime { get; set; }

        public int ProductId { get; set; }
    }
}