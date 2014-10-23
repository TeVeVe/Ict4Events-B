using System;
using System.Collections.Generic;

namespace SharedClasses.Models.Data
{
    public class UserAccount
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public IEnumerable<Group> Groups { get; set; }
        public Wristband Wristband { get; set; }

        public void Rent()
        {
            throw new NotImplementedException();
        }

        public void SetGroup(Group group)
        {
            throw new NotImplementedException();
        }

        public UserAccount(string username, string password, IEnumerable<Group> groups)
        {
            Username = username;
            Password = password;
            Groups = groups;
        }
    }
}