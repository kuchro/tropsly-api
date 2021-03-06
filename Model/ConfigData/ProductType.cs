using System.ComponentModel.DataAnnotations;

namespace tropsly_api.Model.ConfigData
{
    public class ProductType
    {
        [Key]
        public int ProductTypeId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
