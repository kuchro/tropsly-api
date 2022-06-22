using tropsly_api.Model.ConfigData;

namespace tropsly_api.Repository
{
    public interface ICategoryRepository
    {
        Task<Model.ConfigData.Category> Get(int id);
        Task<Model.ConfigData.Category> GetByName(string name);
        Task<IEnumerable<Model.ConfigData.Category>> GetAll();
        Task AddCollection(IList<Model.ConfigData.Category> brands);
        Task Delete(int id);
        Task DeleteByName(string name);
        Task DeleteCollection(IList<Model.ConfigData.Category> names);
        Task Update(Model.ConfigData.Category brand);
    }
}
