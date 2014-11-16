using SharedClasses.Data.Attributes;

namespace SharedClasses.Data.Models
{
    internal class Vote
    {
        [Key]
        [FieldName("VOTEID")]
        public int Id { get; set; }

        public int FileId { get; set; }

        public int UserAccountId { get; set; }

        [DbIgnore]
        public VoteType Type { get; set; }
    }
}