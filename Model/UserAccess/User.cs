namespace tropsly_api.Model.UserAccess
{
    public class User
    {

        public User()
        {
            RefreshToken = new HashSet<RefreshToken>();
        }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public string EmailAddress { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public virtual Role Role { get; set; }

        public virtual Address Address { get; set; }
        public virtual ICollection<RefreshToken> RefreshToken { get; set; }

    }
}
