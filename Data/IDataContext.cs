using Microsoft.EntityFrameworkCore;
using tropsly_api.Model;

namespace tropsly_api.Data
{
    public interface IDataContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<Category> Category { get; set; }
        DbSet<Brand> Brands { get; set; }
        Task<int> SaveChangeAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
