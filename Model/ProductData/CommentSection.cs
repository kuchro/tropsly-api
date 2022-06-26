using System.ComponentModel.DataAnnotations;

namespace tropsly_api.Model
{
    public class CommentSection
    {
        [Key]
        public int CommentId { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }
    }
}
