namespace tropsly_api.Model.Dto
{
    public class CreateProductRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public int MaterialTypeId { get; set; }
        public int ProductTypeId { get; set; }
        public string SerialNumber { get; set; }
        public string Material { get; set; }
        public int UserId { get; set; }
        public int BrandId { get; set; }
        public List<string> Size { get; set; }


    }
}
