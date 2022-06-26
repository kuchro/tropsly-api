using tropsly_api.Model;
using tropsly_api.Model.Dto.Request;

namespace tropsly_api.Repository
{
    public interface IProductRepository
    {
        Task<Product> Get(int id);
        Task<IEnumerable<Product>> GetAll();
        Task Add(Product product);
        Task Delete(int id);
        Task Update(int id, UpdateProductRequest productRequest);
    }
}
