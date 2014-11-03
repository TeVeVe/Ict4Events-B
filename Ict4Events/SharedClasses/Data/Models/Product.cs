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

        public override string ToString()
        {
            return string.Format("Id: {0}, Name: {1}, Description: {2}, Inactive: {3}", Id, Name, Description, Inactive);
        }
    }
}