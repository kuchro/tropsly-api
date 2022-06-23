using tropsly_api.Model.OrderData;
using System.ComponentModel.DataAnnotations;

namespace tropsly_api.Model.ConfigData
{
    public class Order
    {
        public Order()
        {
            OrderedProducts = new List<OrderedProduct>();
        }
        [Key]
        public int ProductOrderId { get; set; }
        public decimal TotalPrice { get; set; }
        public int DeliveryOptionId { get; set; }
        public virtual DeliveryOption? DeliveryOption { get; set; }
        public virtual CustomerPersonalData CustomerPersonalData { get; set; }
        public virtual ICollection<OrderedProduct> OrderedProducts { get; set; }

    }
}
