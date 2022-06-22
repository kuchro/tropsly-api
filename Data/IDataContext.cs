using Microsoft.EntityFrameworkCore;
using tropsly_api.Model;
using tropsly_api.Model.ConfigData;
using tropsly_api.Model.UserAccess;

namespace tropsly_api.Data
{
    public interface IDataContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<Category> Category { get; set; }
        DbSet<Brand> Brands { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<RatingData> RatingData { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Address> Address { get; set; }

        public DbSet<DeliveryOption> DeliveryOptions { get; set; }


        public DbSet<CommentSection> CommentSections { get; set; }
        Task<int> SaveChangeAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
