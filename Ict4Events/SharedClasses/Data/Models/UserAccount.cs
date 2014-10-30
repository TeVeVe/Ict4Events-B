using System;
using System.Collections.Generic;
using SharedClasses.Data.Attributes;

namespace SharedClasses.Data.Models
{
    public class UserAccount
    {
        [Key]
        [FieldName("USERACCOUNT")]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Group Group { get; set; }
        public Wristband Wristband { get; set; }

        public void Rent()
        {
            throw new NotImplementedException();
        }

        public void SetGroup(Group group)
        {
            throw new NotImplementedException();
        }

        public UserAccount(string username, string password, Group group)
        {
            Username = username;
            Password = password;
            Group = group;
        }
    }
}