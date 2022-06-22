using Microsoft.EntityFrameworkCore;
using tropsly_api.Data;
using tropsly_api.Model;
using tropsly_api.Model.Dto.Request;

namespace tropsly_api.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDataContext _context;
        public ProductRepository(IDataContext context)
        {
            _context = context;
        }
        public async Task Add(Product product)
        {
           _context.Products.Add(product);
            await _context.SaveChangeAsync();
        }

        public async Task Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if(product == null)
            {
                throw new NullReferenceException($"Product with `{id}` does not exist.");
            }
            _context.Products.Remove(product);
           await  _context.SaveChangeAsync();


        }

        public async Task<Product> Get(int id) => await _context.Products.FindAsync(id);

        public async Task<IEnumerable<Product>> GetAll() => await _context.Products.ToListAsync();
      

        public async Task Update(int id, UpdateProductRequest productRequest)
        {
            var productDataResponse = await _context.Products.FindAsync(id);

            var productData = productDataResponse;
                productData.Title = productRequest.Title;
                productData.Description = productRequest.Description;
                productData.Price = productRequest.Price;
                productData.Image = productRequest.Image;
              
              
                productData.Quantity = productRequest.Quantity;
                productData.Material = productRequest.Material;

            productData.Size = productRequest.Size;
            
             // _context.Products.Update(productData);
             await _context.SaveChangeAsync();
        }
    }
}
