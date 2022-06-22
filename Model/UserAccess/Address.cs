using System.ComponentModel.DataAnnotations;

namespace tropsly_api.Model.UserAccess
{
    public class Address
    {
        public Address()
        {
            Users = new HashSet<User>();
        }
        [Key]
        public int AddressId { get; set; }
        public string? StreetName { get; set; }
        public string? FlatNumber { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }

        public virtual ICollection<User> Users { get; set; }

    }
}
