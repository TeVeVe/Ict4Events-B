using System;
using System.ComponentModel;
using SharedClasses.Data.Attributes;

namespace SharedClasses.Data.Models
{
    [Table("FILE")]
    public class File : DataModel<File>
    {
        [Key]
        [FieldName("FILEID")]
        public int Id { get; set; }

        [DisplayName("Naam")]
        public string Name { get; set; }

        [DisplayName("Omschrijving")]
        public string Description { get; set; }

        [DisplayName("Geplaatst op")]
        public DateTime PostTime { get; set; }

        [DisplayName("Aantal keren gemarkeerd")]
        public int ReportCount { get; set; }

        [DisplayName("Account")]
        public int UserAccountId { get; set; }

        [DisplayName("Categorie")]
        public int CategoryId { get; set; }
    }
}