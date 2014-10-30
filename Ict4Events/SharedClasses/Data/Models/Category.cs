using System;
using SharedClasses.Data.Attributes;

namespace SharedClasses.Data.Models
{
    [Table("CATEGORY")]
    public class Category
    {
        [Key]
        [FieldName("CATEGORY")]
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("PARENTCATID", "CATEGORYID")]
        public Category ParentCategory { get; set; }
        public string Description { get; set; } 

        public void AddCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
