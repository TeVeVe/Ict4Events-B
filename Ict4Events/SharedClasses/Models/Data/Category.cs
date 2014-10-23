using System;

namespace SharedClasses.Models.Data
{
    public class Category
    {
        public string Name { get; set; }
        public Category ParentCategory { get; set; }

        public void AddCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
