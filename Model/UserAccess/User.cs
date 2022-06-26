using System.ComponentModel.DataAnnotations;

namespace tropsly_api.Model.UserAccess
{
    public class User
    {

        public User()
        {
            RefreshTokens = new HashSet<RefreshToken>();
        }
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public string EmailAddress { get; set; }
        public string? Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public int AddressId { get; set; }
        public virtual Address? Address { get; set; }
        public virtual ICollection<RefreshToken> RefreshTokens { get; set; }

        //public virtual ICollection<Product> Products { get; set; }

    }
}
