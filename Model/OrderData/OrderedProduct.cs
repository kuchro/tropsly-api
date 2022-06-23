using System.ComponentModel.DataAnnotations;
using tropsly_api.Model.ConfigData;

namespace tropsly_api.Model.OrderData
{
    public class OrderedProduct
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string SerialNumber { get; set; }
        public List<string> Size { get; set; } = new List<string>();
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
