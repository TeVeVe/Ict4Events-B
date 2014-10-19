﻿using System;

namespace SharedClasses.Models
{
    public class File
    {
        public string Decription { get; set; }
        public string Name { get; set; }
        public DateTime PostTime { get; set; }
        public int ReportCount { get; set; }
        public UserAccount UserAccount { get; set; }

        public File(UserAccount userAccount, string decription)
        {
            UserAccount = userAccount;
            Decription = decription;
        }

        public void AddLike(UserAccount userAccount)
        {
            throw new NotImplementedException();
        }

        public void AddComment(UserAccount userAccount, string content)
        {
            throw new NotImplementedException();
        }

        public void ReportedBy(UserAccount account)
        {
            throw new NotImplementedException();
        }
    }
}