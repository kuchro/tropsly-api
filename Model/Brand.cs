using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tropsly_api.Model
{
    public class Brand
    {
        public int Id { get; set; }
        //public int BrandId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
