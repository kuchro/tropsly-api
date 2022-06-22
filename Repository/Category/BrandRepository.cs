using Microsoft.EntityFrameworkCore;
using tropsly_api.Data;
using tropsly_api.Model.ConfigData;

namespace tropsly_api.Repository
{
    public class BrandRepository : IBrandRepository
    {
        private readonly IDataContext _context;

        public BrandRepository(IDataContext context)
        {
            _context = context;
        }

        public async Task AddCollection(IList<Brand> brands)
        {
            _context.Brands.AddRange(brands);
            await _context.SaveChangeAsync();
        }

        public async Task Delete(int id)
        {
            var brand = await _context.Brands.FindAsync(id);
            if (brand == null)
            {
                throw new NullReferenceException($"Product with `{id}` does not exist.");
            }
            _context.Brands.Remove(brand);
            await _context.SaveChangeAsync();

        }

        public async Task DeleteByName(string name)
        {
            var Brand = await _context.Brands.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());
            if (Brand == null)
            {
                throw new NullReferenceException($"Product with `{name}` does not exist.");
            }
            _context.Brands.Remove(Brand);
            await _context.SaveChangeAsync();
        }

        public async Task DeleteCollection(IList<Brand> brands)
        {

            _context.Brands.RemoveRange(brands);
            await _context.SaveChangeAsync();
        }

        public async Task<Brand> Get(int id) => await _context.Brands.FindAsync(id);
        public async Task<Brand> GetByName(string name) =>
            await _context.Brands.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());
        public async Task<IEnumerable<Brand>> GetAll() => await _context.Brands.ToListAsync();


        public async Task Update(Brand brand)
        {
            var brandToUpdate = await _context.Brands.FindAsync(brand.BrandId);
            if (brandToUpdate == null)
            {
                throw new NullReferenceException($"Product with `{brand.BrandId}` does not exist.");
            }
            brandToUpdate.Name = brand.Name;
         
            await _context.SaveChangeAsync();
        }
    }
}
