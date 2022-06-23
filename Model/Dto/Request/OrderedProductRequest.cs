namespace tropsly_api.Model.Dto.Request
{
    public class OrderedProductRequest
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string SerialNumber { get; set; }
        public int OrderId { get; set; }
        public List<string> Size { get; set; }
    }
}
