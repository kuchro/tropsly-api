using tropsly_api.Model.ConfigData;
using System.ComponentModel.DataAnnotations;

namespace tropsly_api.Model.OrderData
{
    public class CustomerPersonalData
    {
        [Key]
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public virtual CustomerAddress? CustomerAddress { get; set; }
        public int ProductOrderId { get; set; }
        public virtual Order? ProductOrder { get; set; }

    }
}
