using System;
using System.ComponentModel;
using SharedClasses.Data.Attributes;

namespace SharedClasses.Data.Models
{
    [Table("CATEGORY")]
    public class Category : DataModel<Category>
    {
        [Key]
        [FieldName("CATEGORYID")]
        public int Id { get; set; }
        [DisplayName("Naam")]
        public string Name { get; set; }
        [ForeignKey("PARENTCATID", "CATEGORYID")]
        public Category ParentCategory { get; set; }
        [DisplayName("Omschrijving")]
        public string Description { get; set; }
    }
}
