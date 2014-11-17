using System;
using SharedClasses.Data.Attributes;

namespace SharedClasses.Data.Models
{
    [Table("COMMENT")]
    public class Comment
    {
        [Key]
        [FieldName("COMMENTID")]
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime PostTime { get; set; }
        [ForeignKey("PARENTID", "COMMENTID")]
        public Comment ParentComment { get; set; }
        [ForeignKey("USERACCOUNTID")]
        public UserAccount UserAccount { get; set; }
        [ForeignKey("FILEID")]
        public File FileId { get; set; }
    }
}
