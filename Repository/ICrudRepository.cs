namespace tropsly_api.Repository
{
    public interface ICrudRepository<T> where T : class
    {
        Task<T> Get(int id);
        Task<IEnumerable<T>> Get();
        Task<T> Create(T entity);
        Task AddCollection(IList<T> dataList);
        Task<T> Update(T entity);
        Task Delete(int id);
        Task DeleteCollection(IList<T> names);
    }
}
