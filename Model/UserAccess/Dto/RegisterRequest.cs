namespace tropsly_api.Model.UserAccess.Dto
{
    public class RegisterRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }

        public AddressDto Address { get; set; }

    }
}
