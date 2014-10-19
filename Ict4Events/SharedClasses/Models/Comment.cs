using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedClasses.Models
{
    class Comment
    {
        public string Content { get; set; }
        public DateTime PostTime { get; set; }

        public Comment(string content, UserAccount account)
        {
            Content = content;

            throw new NotImplementedException();
        }
    }
}
