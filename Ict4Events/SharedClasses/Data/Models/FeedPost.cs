﻿using System;

namespace SharedClasses.Data.Models
{
    class FeedPost
    {
        public string Content { get; set; }
        public DateTime PostTime { get; set; }
        public UserAccount UserAccount { get; set; }

        public FeedPost(UserAccount account, string content)
        {
            throw new NotImplementedException();
        }
    }
}
