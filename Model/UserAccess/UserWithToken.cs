namespace tropsly_api.Model.UserAccess
{
    public class UserWithToken : User
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

        public UserWithToken(User user)
        {
            this.UserId = user.UserId;
            this.EmailAddress = user.EmailAddress;
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.CreatedDate = user.CreatedDate;
            this.Gender = user.Gender;
            this.PhoneNumber = user.PhoneNumber;

            this.Role = user.Role;
        }
    }
}
