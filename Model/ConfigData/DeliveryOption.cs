using System.ComponentModel.DataAnnotations;

namespace tropsly_api.Model.ConfigData
{
    public class DeliveryOption
    {
        public DeliveryOption()
        {
            Orders = new List<Order>();
        }
        [Key]
        public int DeliveryId { get; set; }
        public string DeliveryName { get; set; }
        public Decimal DeliveryPrice { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string ExtraOptions { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
