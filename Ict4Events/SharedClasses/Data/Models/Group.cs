using System;
using System.Collections.Generic;
using SharedClasses.Data.Attributes;

namespace SharedClasses.Data.Models
{
    [Table("GROUP")]
    public class Group : DataModel<Group>
    {
        [Key]
        [FieldName("GROUPID")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}