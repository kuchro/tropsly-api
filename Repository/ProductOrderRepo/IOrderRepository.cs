using System.Collections.ObjectModel;
using tropsly_api.Model.ConfigData;

namespace tropsly_api.Repository.ProductOrderRepo
{
    public interface IOrderRepository 
    {
        Task<Order> Add(Order productOrder);
        Task Update(Order productOrder);
        Task Delete(Order productOrder);
        Task<Order> Get(int id);
        Task<IEnumerable<Order>> Get(); 
    }
}
