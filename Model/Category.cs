using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tropsly_api.Model
{
    public class Category
    {
        public int Id { get; set; }

        //public int CategoryId { get; set; }
        public string Name { get; set; }

        public DateTime CreatedDateTime { get; set; }
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
