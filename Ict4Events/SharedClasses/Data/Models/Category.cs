﻿using System;
using SharedClasses.Data.Attributes;

namespace SharedClasses.Data.Models
{
    [Table("CATEGORY")]
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }
        [FieldName("PARENTCATID")]
        public Category ParentCategory { get; set; }
        public string Description { get; set; } 

        public void AddCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
