namespace tropsly_api.Model.Dto
{
    public class CreateProductRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
        public string? Category { get; set; }
        public string Material { get; set; }
        public int UserId { get; set; }
        public string? Brand { get; set; }
        public List<string> Size { get; set; }


    }
}
