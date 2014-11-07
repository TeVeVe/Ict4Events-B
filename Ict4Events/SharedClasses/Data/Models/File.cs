using System;
using SharedClasses.Data.Attributes;

namespace SharedClasses.Data.Models
{
    [Table("FILE")]
    public class File : DataModel<File>
    {
        [Key]
        [FieldName("FILEID")]
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public DateTime PostTime { get; set; }
        public int ReportCount { get; set; }
        public int UserAccountId { get; set; }
        public int CategoryId { get; set; }

        public File()
        {
            
        }
    }
}