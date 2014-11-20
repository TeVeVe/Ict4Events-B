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
        [System.ComponentModel.DisplayName("Id")]
        public int Id { get; set; }
        [System.ComponentModel.DisplayName("Naam")]
        public string Name { get; set; }
        [System.ComponentModel.DisplayName("Beschrijving")]
        public string Description { get; set; }
        [System.ComponentModel.DisplayName("Foto")]
        public DbImage Image { get; set; }

        [System.ComponentModel.DisplayName("Prijs")]
        public decimal Price { get; set; }
        [System.ComponentModel.DisplayName("Inactief")]
        public bool Inactive { get; set; }

        public override string ToString()
        {
            return string.Format("LabelText: {0}, Description: {1}, Price: {2}, Inactive: {3}", Name, Description, Price, Inactive);
        }
    }
}