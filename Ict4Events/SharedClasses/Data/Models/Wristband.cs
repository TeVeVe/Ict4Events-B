using System;
using SharedClasses.Data.Attributes;

namespace SharedClasses.Data.Models
{
    public class Wristband : DataModel<Wristband>
    {
        [Key]
        [FieldName("WRISTBANDID")]
        public int Id { get; set; }
        public string VisitorCode { get; set; }
        public UserAccount UserAccount { get; set; }

        public void SetAccount(UserAccount userAccount)
        {
            throw new NotImplementedException();
        }
    }
}