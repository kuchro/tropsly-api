using System.ComponentModel.DataAnnotations;

namespace tropsly_api.Model.UserAccess
{
    public class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }
        [Key]
        public int RoleId { get; set; }
        public string RoleDesc { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
