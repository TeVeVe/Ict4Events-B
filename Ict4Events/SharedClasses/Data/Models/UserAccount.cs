using System;
using System.Collections.Generic;
using SharedClasses.Data.Attributes;

namespace SharedClasses.Data.Models
{
    [Table("USERACCOUNT")]
    public class UserAccount : DataModel<UserAccount>
    {
        [Key]
        [FieldName("USERACCOUNTID")]
        public int Id { get; set; }

        public string VisitorCode { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        [FieldName("GroupId")]
        public int GroupId { get; set; }
        [DbIgnore]
        public Visitor Wristband { get; set; }
    }
}