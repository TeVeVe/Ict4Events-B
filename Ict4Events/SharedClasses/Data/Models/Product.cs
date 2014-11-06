using SharedClasses.Data.Attributes;
using SharedClasses.Data.Models.Types;

namespace SharedClasses.Data.Models
{
    [Table("PRODUCT")]
    public class Product : DataModel<Product>
    {
        [Key]
        [FieldName("PRODUCTID")]
        public int Id { get; set; }

        public string Description { get; set; }
        public DbImage Image { get; set; }
        public bool Inactive { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return string.Format("LabelText: {0}, Description: {1}, Price: {2}, Inactive: {3}", Name, Description, Price, Inactive);
        }
    }
}