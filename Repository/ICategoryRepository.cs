using tropsly_api.Model;

namespace tropsly_api.Repository
{
    public interface ICategoryRepository
    {
        Task<Category> Get(int id);
        Task<Category> GetByName(string name);
        Task<IEnumerable<Category>> GetAll();
        Task AddCollection(IList<Category> brands);
        Task Delete(int id);
        Task DeleteByName(string name);
        Task DeleteCollection(IList<Category> names);
        Task Update(Category brand);
    }
}
