namespace tropsly_api.Model.Dto.Request
{
    public class UpdateProductRequest
    {
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string SerialNumber { get; set; }
        public Decimal  Price { get; set; }
        public int Quantity { get; set; }
        public List<string> Size { get; set; }

    }
}
