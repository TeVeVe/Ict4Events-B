using System;

namespace SharedClasses.Models.Data
{
    public class Comment
    {
        public string Content { get; set; }
        public DateTime PostTime { get; set; }
        public Comment ParentComment { get; set; }
        public UserAccount UserAccount { get; set; }

        public Comment(string content, UserAccount account)
        {
            Content = content;

            throw new NotImplementedException();
        }
    }
}
