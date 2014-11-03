using SharedClasses.Data.Attributes;

namespace SharedClasses.Data.Models
{
    class Vote
    {
        [Key]
        [FieldName("VOTEID")]
        public int Id { get; set; }
        [ForeignKey("FILEID")]
        public File File { get; set; }  
        [DbIgnore]
        public VoteType Type { get; set; }
    }
}
