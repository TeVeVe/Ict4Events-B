using SharedClasses.Data.Attributes;
using System;

namespace SharedClasses.Data.Models
{
    [Table("FEEDPOST")]
    class FeedPost
    {
        [Key]
        [FieldName("FEEDPOSTID")]
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime PostTime { get; set; }
        [ForeignKey("USERACCOUNTID")]
        public UserAccount UserAccount { get; set; }

        public FeedPost(UserAccount account, string content)
        {
            throw new NotImplementedException();
        }   
    }
}
