using SharedClasses.Data.Attributes;

namespace SharedClasses.Data.Models
{
    [Table("VOTE")]
    public class Vote : DataModel<Vote>
    {
        [Key]
        [FieldName("VOTEID")]
        public int Id { get; set; }
        public int FileId { get; set; }
        public int UserAccountId { get; set; }
        [FieldName("VOTETYPE")]
        public bool Type { get; set; }
    }
}