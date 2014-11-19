using System.ComponentModel;
using SharedClasses.Data.Attributes;
using SharedClasses.Data.Models.Types;

namespace SharedClasses.Data.Models
{
    [Table("PRODUCT")]
    public class Product : DataModel<Product>
    {
        [Key]
        [FieldName("PRODUCTID")]
        [DisplayName("Id")]
        public int Id { get; set; }
        [DisplayName("Beschrijving")]
        public string Description { get; set; }
        [DisplayName("Foto")]
        public DbImage Image { get; set; }
        [DisplayName("Inactief")]
        public bool Inactive { get; set; }
        [DisplayName("Naam")]
        public string Name { get; set; }
        [DisplayName("Prijs")]
        public decimal Price { get; set; }

        public override string ToString()
        {
            return string.Format("LabelText: {0}, Description: {1}, Price: {2}, Inactive: {3}", Name, Description, Price, Inactive);
        }
    }
}