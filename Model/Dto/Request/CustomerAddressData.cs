namespace tropsly_api.Model.Dto.Request
{
    public class CustomerAddressData
    {
        public string StreetName { get; set; }
        public string? FlatNumber { get; set; }
        public string HouseNumber { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string? Region { get; set; }
    }
}
