using tropsly_api.Model.OrderData;

namespace tropsly_api.Repository.ProductOrderRepo
{
    public interface ICustomerPersonalDataRepository
    {
        Task<CustomerPersonalData> Add(CustomerPersonalData productOrder);
        Task Update(CustomerPersonalData productOrder);
        Task Delete(CustomerPersonalData productOrder);
        Task<CustomerPersonalData> Get(int id);
        Task<CustomerPersonalData> GetByOrderId(int id);
        Task<IEnumerable<CustomerPersonalData>> Get();
    }
}
