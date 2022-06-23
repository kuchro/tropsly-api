using System.ComponentModel.DataAnnotations;
using tropsly_api.Model.UserAccess;
using tropsly_api.Model.ConfigData;
using tropsly_api.Model.OrderData;

namespace tropsly_api.Model
{
    public class Product
    {
        public Product()
        {
            Size= new List<string>();
            CommentSections = new List<CommentSection>();
            RatingDatas = new List<RatingData>();
        }
        [Key]
        public int ProductId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public DateTime DateCreated { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int? CategoryId { get; set; }
        public virtual Category? Category { get; set; } 
        public string Material { get; set; }
        public int? BrandId { get; set; }
        public virtual Brand? Brand { get; set; }
        public List<string> Size { get; set; }
        public virtual ICollection<RatingData>? RatingDatas { get; set; }
        public virtual ICollection<CommentSection>? CommentSections { get; set; }
        // public int CreatedByUserId { get; set; }
        //public virtual User? User { get; set; }
    }
}
