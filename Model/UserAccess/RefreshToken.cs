using System.ComponentModel.DataAnnotations;

namespace tropsly_api.Model.UserAccess
{
    public class RefreshToken
    {
        [Key]
        public int TokenId { get; set; }
        public int UserId { get; set; }
        public string Token { get; set; }
        public DateTime ExpiryDate { get; set; }

        public virtual User User { get; set; }
    }
}
