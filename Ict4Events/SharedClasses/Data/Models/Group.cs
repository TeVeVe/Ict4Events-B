using System;
using System.Collections.Generic;

namespace SharedClasses.Data.Models
{
    public class Group
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<Privilege> Privileges { get; set; }

        public void Add(Privilege privilege)
        {
            throw new NotImplementedException();
        }

        public void AssignTo(UserAccount userAccount)
        {
            throw new NotImplementedException();
        }
    }
}