namespace tropsly_api.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public DateTime DateCreated { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int? CategoryId { get; set; }
        public virtual Category? Category { get; set; } 
        public string Material { get; set; }
        public int? BrandId { get; set; }
        public virtual Brand? Brand { get; set; }
        public List<string> Size { get; set; }
    }
}
