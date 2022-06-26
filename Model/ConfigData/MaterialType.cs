using System.ComponentModel.DataAnnotations;

namespace tropsly_api.Model.ConfigData
{
    public class MaterialType
    {
        [Key]
        public int MaterialTypeId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
