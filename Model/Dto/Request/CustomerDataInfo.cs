namespace tropsly_api.Model.Dto.Request
{
    public class CustomerDataInfo
    {
        public string FirstName { get; set; }
        public int LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

        public CustomerAddressData CustomerAddressData { get; set; }
    }
}
