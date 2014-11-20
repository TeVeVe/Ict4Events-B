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
        [System.ComponentModel.DisplayName("Naam")]
        public string Name { get; set; }
        [System.ComponentModel.DisplayName("Omschrijving")]
        public string Description { get; set; }
        [System.ComponentModel.DisplayName("Geplaatst op")]
        public DateTime PostTime { get; set; }
        [System.ComponentModel.DisplayName("Aantal keren gemarkeerd")]
        public int ReportCount { get; set; }
        [System.ComponentModel.DisplayName("Account")]
        public int UserAccountId { get; set; }
        [System.ComponentModel.DisplayName("Categorie")]
        public int CategoryId { get; set; }
    }
}