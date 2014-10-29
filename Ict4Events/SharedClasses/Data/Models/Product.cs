﻿using System.Drawing;
using SharedClasses.Data.AbstractClasses;
using SharedClasses.Data.Attributes;

namespace SharedClasses.Data.Models
{

    [Table("PRODUCT")]
    public class Product : DataModel<Product>
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        [DbIgnore]
        public Image Image { get; set; }
        public bool Inactive { get; set; }
        public string Name { get; set; }
    }
}