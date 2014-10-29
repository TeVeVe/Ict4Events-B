using SharedClasses.Data.Attributes;

namespace SharedClasses.Data.Models
{
    class Like
    {
        [Key]
        [FieldName("LIKE")]
        public int Id { get; set; }
        [ForeignKey("FILEID")]
        public File File { get; set; }  
        [DbIgnore]
        public LikeType Type { get; set; }
    }
}
