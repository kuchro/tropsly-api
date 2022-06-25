namespace tropsly_api.Model.Dto.Request
{
    public class CreateOrderRequest
    {
        public decimal TotalPrice { get; set; }
        public int DeliveryId { get; set; }
        public string OrderNumber { get; set; }
        public CustomerDataInfo CustomerDataInfo { get; set; }

        public IEnumerable<OrderedProductRequest> Products { get; set; }
    }
}
