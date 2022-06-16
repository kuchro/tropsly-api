using Microsoft.EntityFrameworkCore;
using tropsly_api.Model;

namespace tropsly_api.Data
{
    public class DataContext : DbContext,IDataContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>()
                .HasOne(b => b.Category)
                .WithMany(i => i.Products)
                .HasForeignKey(i=> i.CategoryId)
                .OnDelete(DeleteBehavior.SetNull);


            modelBuilder.Entity<Product>()
                .HasOne(b => b.Brand)
                .WithMany(i => i.Products)
                .HasForeignKey(i=>i.BrandId)
                .OnDelete(DeleteBehavior.SetNull);


            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                    .WithOne(e => e.Category)
                    .HasForeignKey(e => e.CategoryId)
                    .OnDelete(DeleteBehavior.SetNull);

        }

        public Task<int> SaveChangeAsync(CancellationToken cancellationToken) => base.SaveChangesAsync(cancellationToken);
    }
}
