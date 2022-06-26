using Microsoft.EntityFrameworkCore;
using tropsly_api.Data;
using tropsly_api.Model;

namespace tropsly_api.Repository
{
    public class CrudRepository<T> : ICrudRepository<T> where T : class
    {
        protected readonly DataContext _context;

        public CrudRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<T> Create(T entity)
        {
            _context.Set<T>().Add(entity);
           await _context.SaveChangeAsync();
           return entity;
        }

        public async Task AddCollection(IList<T> dataList)
        {
            _context.Set<T>().AddRange(dataList);
            await _context.SaveChangeAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCollection(IList<T> data)
        {
            _context.Set<T>().RemoveRange(data);
            await _context.SaveChangeAsync();
        }

        public async Task<T> Get(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);

            return entity;
        }

        public async Task<IEnumerable<T>> Get()
        {
            var entities = await _context.Set<T>().ToListAsync();
            return entities; 
        }

        public Task<T> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
