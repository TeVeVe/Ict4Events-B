using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedClasses.Models
{
    class FeedPost
    {
        public string Content { get; set; }
        public DateTime PostTime { get; set; }

        public FeedPost(UserAccount account, string content)
        {
            throw new NotImplementedException();
        }
    }
}
