using tropsly_api.Model.ConfigData;

namespace tropsly_api.Repository
{
    public interface IBrandRepository
    {
        Task<Brand> Get(int id);
        Task<Brand> GetByName(string name);
        Task<IEnumerable<Brand>> GetAll();
        Task AddCollection(IList<Brand> brands);
        Task Delete(int id);
        Task DeleteByName(string name);
        Task DeleteCollection(IList<Brand> names);
        Task Update(Brand brand);
    }
}
