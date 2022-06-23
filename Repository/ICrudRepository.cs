namespace tropsly_api.Repository
{
    public interface ICrudRepository<T> where T : class
    {
        Task<T> Get(int id);
        Task<IEnumerable<T>> Get();
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task Delete(T t);
    }
}
