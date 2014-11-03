using System;
using System.Runtime.InteropServices;
using SharedClasses.Data.Attributes;

namespace SharedClasses.Data.Models
{
    public class Privilege
    {
        [Key]
        [FieldName("PRIVILEGEID")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public void AssignTo(Group group)
        {
            throw new NotImplementedException();
        }
    }
}