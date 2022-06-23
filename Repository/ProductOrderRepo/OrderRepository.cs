using Microsoft.EntityFrameworkCore;
using tropsly_api.Data;
using tropsly_api.Model.ConfigData;

namespace tropsly_api.Repository.ProductOrderRepo
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IDataContext _dataContext;
        public OrderRepository(IDataContext dataContext)
        {
            this._dataContext = dataContext;
        }
        public async Task<int> Add(Order productOrder)
        {
            _dataContext.Orders.Add(productOrder);
           await _dataContext.SaveChangeAsync();
            return productOrder.ProductOrderId;
        }

        public async Task Delete(Order productOrder)
        {
            _dataContext.Orders.Remove(productOrder);
            await _dataContext.SaveChangeAsync();
        }

        public async Task<Order> Get(int id) => await _dataContext.Orders.FindAsync(id);


        public async Task<IEnumerable<Order>> Get()
        => await _dataContext.Orders.ToListAsync();

        public Task Update(Order productOrder)
        {
            throw new NotImplementedException();
        }
    }
}
