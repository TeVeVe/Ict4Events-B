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
        [DbIgnore]
        public Group Group { get; set; }
        [DbIgnore]
        public Wristband Wristband { get; set; }

        public void Rent()
        {
            throw new NotImplementedException();
        }

        public void SetGroup(Group group)
        {
            throw new NotImplementedException();
        }
    }
}