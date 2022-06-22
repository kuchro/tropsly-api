namespace tropsly_api.Repository
{
    public interface ICrudRepository<T> where T : class
    {
        Task<T> Get(int id);
        Task<IEnumerable<T>> Get();
        T Create(T entity);
    }
}
