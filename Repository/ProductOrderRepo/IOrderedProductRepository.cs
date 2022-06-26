using tropsly_api.Model.OrderData;

namespace tropsly_api.Repository.ProductOrderRepo
{
    public interface IOrderedProductRepository
    {
        Task<int> Add(OrderedProduct productOrder);
        Task Update(OrderedProduct productOrder);
        Task Delete(OrderedProduct productOrder);
        Task<OrderedProduct> Get(int id);
        Task<IEnumerable<OrderedProduct>> Get();
    }
}
