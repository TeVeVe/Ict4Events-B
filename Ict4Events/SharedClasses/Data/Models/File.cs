using System;
using SharedClasses.Data.Attributes;

namespace SharedClasses.Data.Models
{
    [Table("FILE")]
    public class File
    {
        [Key]
        [FieldName("FILE")]
        public int Id { get; set; }
        public string Decription { get; set; }
        public string Name { get; set; }
        public DateTime PostTime { get; set; }
        public int ReportCount { get; set; }
        [DbIgnore]
        public UserAccount UserAccount { get; set; }
        [DbIgnore]
        public Category Category { get; set; }

        public File(UserAccount userAccount, string decription)
        {
            UserAccount = userAccount;
            Decription = decription;
        }

        public void AddLike(UserAccount userAccount)
        {
            throw new NotImplementedException();
        }

        public void AddComment(UserAccount userAccount, string content)
        {
            throw new NotImplementedException();
        }

        public void ReportedBy(UserAccount account)
        {
            throw new NotImplementedException();
        }
    }
}