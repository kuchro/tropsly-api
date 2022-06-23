using tropsly_api.Model.OrderData;

namespace tropsly_api.Repository.ProductOrderRepo
{
    public interface ICustomerAddressRepository
    {
        Task<CustomerAddress> Add(CustomerAddress productOrder);
        Task Update(CustomerAddress productOrder);
        Task Delete(CustomerAddress productOrder);
        Task<CustomerAddress> Get(int id);
        Task<IEnumerable<CustomerAddress>> Get();
    }
}
