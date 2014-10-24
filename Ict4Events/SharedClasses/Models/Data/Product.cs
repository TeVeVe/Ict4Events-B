﻿using System.Drawing;

namespace SharedClasses.Models.Data
{
    public class Product
    {
        public string Description { get; set; }
        public Image Image { get; set; }
        public bool Inactive { get; set; }
        public string Name { get; set; }

    }
}