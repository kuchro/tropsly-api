using tropsly_api.Model.ConfigData;

namespace tropsly_api.Repository.Category
{
    public interface IDeliveryOptionRepository
    {
        Task<DeliveryOption> Get(int id);
        Task<IEnumerable<DeliveryOption>> GetAll();
        Task Add(DeliveryOption deliveryOption);
    }
}
