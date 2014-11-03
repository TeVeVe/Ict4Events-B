using System;
using System.Collections.Generic;
using SharedClasses.Data.Attributes;

namespace SharedClasses.Data.Models
{
    [Table("GROUP")]
    public class Group
    {
        [Key]
        [FieldName("GROUPID")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        [DbIgnore]
        [ForeignKey("PRIVELEGEID")]
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