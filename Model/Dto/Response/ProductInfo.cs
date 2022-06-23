namespace tropsly_api.Model.Dto.Response
{
    public class ProductInfo
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string SerialNumber { get; set; }
        public List<string> Size { get; set; } = new List<string>();
    }
}
