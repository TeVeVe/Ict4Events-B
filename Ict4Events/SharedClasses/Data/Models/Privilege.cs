﻿using System;

namespace SharedClasses.Data.Models
{
    public class Privilege
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public void AssignTo(Group group)
        {
            throw new NotImplementedException();
        }
    }
}