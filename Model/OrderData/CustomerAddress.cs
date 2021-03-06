using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tropsly_api.Model.OrderData
{
    public class CustomerAddress
    {
        [Key]
        public int AddressId { get; set; }
        public string StreetName { get; set; }
        public string? FlatNumber { get; set; }
        public string HouseNumber { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string? Region { get; set; }

        public int CustomerId { get; set; }
        public virtual CustomerPersonalData CustomerPersonalData { get; set; }
    }
}
