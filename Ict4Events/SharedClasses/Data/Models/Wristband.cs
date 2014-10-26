using System;

namespace SharedClasses.Data.Models
{
    public class Wristband
    {
        public string VisitorCode { get; set; }
        public UserAccount UserAccount { get; set; }

        public void SetAccount(UserAccount userAccount)
        {
            throw new NotImplementedException();
        }
    }
}