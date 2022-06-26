using System.ComponentModel.DataAnnotations;

namespace tropsly_api.Model
{
    public class RatingData
    {
        [Key]
        public int RatingId { get; set; }
        public int RatingScore { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
