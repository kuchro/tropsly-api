using Microsoft.EntityFrameworkCore;
using tropsly_api.Model;
using tropsly_api.Model.ConfigData;
using tropsly_api.Model.OrderData;
using tropsly_api.Model.UserAccess;

namespace tropsly_api.Data
{
    public class DataContext : DbContext, IDataContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Brand> Brands { get; set; }

        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<RatingData> RatingData { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<CommentSection> CommentSections { get; set; }
        public DbSet<DeliveryOption> DeliveryOptions { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderedProduct> OrderedProducts { get; set; }

        public DbSet<CustomerPersonalData> CustomerPersonalData { get; set; }
        public DbSet<CustomerAddress> CustomerAddresses { get; set; }


        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");
                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.HasOne(c => c.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(b => b.Brand)
                .WithMany(i => i.Products)
                .HasForeignKey(i => i.BrandId)
                .OnDelete(DeleteBehavior.SetNull);

                /* entity.HasOne(u => u.User)
                 .WithMany(p => p.Products)
                 .HasForeignKey(u => u.CreatedByUserId)
                 .OnDelete(DeleteBehavior.SetNull);*/

            });

            modelBuilder.Entity<CommentSection>(entity =>
            {
                entity.ToTable("comment_section");
                //entity.Property(e => e.CommentId).HasColumnName("comment_id");

                entity.HasOne(p => p.Product)
                .WithMany(c => c.CommentSections)
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<RatingData>(entity =>
            {
                entity.ToTable("Rating");
                entity.Property(e => e.RatingId).HasColumnName("rating_id");
                entity.HasOne(p => p.Product)
                .WithMany(c => c.RatingDatas)
                .HasForeignKey(p => p.ProductId);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");
                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(r => r.Address)
                .WithMany(u => u.Users)
                .HasForeignKey(r => r.AddressId);

                entity.HasOne(r => r.Role)
                .WithMany(u => u.Users)
                .HasForeignKey(r => r.RoleId);
            });

            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.ToTable("Refresh_Token");
                entity.Property(e => e.TokenId).HasColumnName("token_id");
                entity.HasOne(d => d.User)
                 .WithMany(p => p.RefreshTokens)
                 .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<OrderedProduct>(entity =>
            {
                entity.ToTable("ordered_products");
                entity.HasOne(p => p.Order)
                .WithMany(c => c.OrderedProducts)
                .HasForeignKey(p => p.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<CustomerPersonalData>(entity =>
            {
                entity.ToTable("customer_personal");
                entity.Property(e => e.CustomerId).HasColumnName("customer_id");
                entity.HasOne(c => c.CustomerAddress)
                .WithOne(p => p.CustomerPersonalData)
                .HasForeignKey<CustomerAddress>(c => c.AddressId);

            });





        }

        public Task<int> SaveChangeAsync(CancellationToken cancellationToken = new CancellationToken()) => base.SaveChangesAsync(cancellationToken);
    }
}
