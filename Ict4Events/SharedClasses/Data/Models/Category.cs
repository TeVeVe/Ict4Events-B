using System.ComponentModel;
using SharedClasses.Data.Attributes;

namespace SharedClasses.Data.Models
{
    [Table("CATEGORY")]
    public class Category : DataModel<Category>
    {
        [Key]
        [FieldName("CATEGORYID")]
        public int? Id { get; set; }

        [DisplayName("Naam")]
        public string Name { get; set; }

        [FieldName("PARENTCATID")]
        public int? ParentCategory { get; set; }

        [DisplayName("Omschrijving")]
        public string Description { get; set; }
    }
}