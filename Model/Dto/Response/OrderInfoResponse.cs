using tropsly_api.Model.Dto.Request;

namespace tropsly_api.Model.Dto.Response
{
    public class OrderInfoResponse
    {
        public string Delivery { get; set; }
        public virtual CustomerDataInfo CustomerDataInfo { get; set; }
        public string TotalPrice { get; set; }
        public virtual IEnumerable<ProductInfo> ProductInfo { get; set; }
    }
}
