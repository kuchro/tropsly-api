using Microsoft.EntityFrameworkCore;
using tropsly_api.Data;
using tropsly_api.Model;

namespace tropsly_api.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IDataContext _context;

        public CategoryRepository(IDataContext context)
        {
            _context = context;
        }

        public async Task AddCollection(IList<Category> category)
        {
            _context.Category.AddRange(category);
            await _context.SaveChangeAsync();
        }

        public async Task Delete(int id)
        {
            var Category = await _context.Category.FindAsync(id);
            if (Category == null)
            {
                throw new NullReferenceException($"Product with `{id}` does not exist.");
            }
            _context.Category.Remove(Category);
            _context.SaveChangeAsync();


        }

        public async Task DeleteByName(string name)
        {
            var Category = await _context.Category.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());
            if (Category == null)
            {
                throw new NullReferenceException($"Product with `{name}` does not exist.");
            }
            _context.Category.Remove(Category);
            await _context.SaveChangeAsync();
        }

        public async Task DeleteCollection(IList<Category> categories)
        {
            _context.Category.RemoveRange(categories);
            await _context.SaveChangeAsync();
        }


        public async Task<Category> Get(int id) => await _context.Category.FindAsync(id);
        public async Task<Category> GetByName(string name) =>
          await _context.Category.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());
        public async Task<IEnumerable<Category>> GetAll() => await _context.Category.ToListAsync();



        public async Task Update(Category category)
        {
            var CategoryToUpdate = await _context.Category.FindAsync(category.Id);
            if (CategoryToUpdate == null)
            {
                throw new NullReferenceException($"Product with `{category.Id}` does not exist.");
            }
            CategoryToUpdate.Name = category.Name;

            await _context.SaveChangeAsync();
        }

    }
}
