using System;
using System.ComponentModel;
using SharedClasses.Data.Attributes;

namespace SharedClasses.Data.Models
{
    [Table("COMMENT")]
    public class Comment
    {
        [Key]
        [FieldName("COMMENTID")]
        public int Id { get; set; }
        [DisplayName("Bericht")]
        public string Content { get; set; }
        [DisplayName("Geplaatst op")]
        public DateTime PostTime { get; set; }
        [DbIgnore]
        public Comment ParentComment { get; set; }
        [DbIgnore]
        public UserAccount UserAccount { get; set; }
        [DbIgnore]
        public File FileId { get; set; }
    }
}
