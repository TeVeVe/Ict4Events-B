using System;
using SharedClasses.Data.Attributes;

namespace SharedClasses.Data.Models
{
    [Table("FEEDPOST")]
    public class FeedPost : DataModel<FeedPost>
    {
        [Key]
        [FieldName("FEEDPOSTID")]
        public int Id { get; set; }

        public string Content { get; set; }
        public DateTime PostTime { get; set; }

        [FieldName("USERACCOUNTID")]
        public int UserAccount { get; set; }
    }
}