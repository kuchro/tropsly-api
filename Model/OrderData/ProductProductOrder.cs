using tropsly_api.Model.ConfigData;

namespace tropsly_api.Model.OrderData
{
    public class ProductProductOrder
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int ProductOrderId { get; set; }
        public ProductOrder ProductOrder { get; set; }
    }
}
