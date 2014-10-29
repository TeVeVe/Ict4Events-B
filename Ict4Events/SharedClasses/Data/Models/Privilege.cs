﻿using System;
using SharedClasses.Data.Attributes;

namespace SharedClasses.Data.Models
{
    public class Privilege
    {
        [Key]
        public int PrivilegeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public void AssignTo(Group group)
        {
            throw new NotImplementedException();
        }
    }
}