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
        public async Task<Order> Add(Order productOrder)
        {
            _dataContext.Orders.Add(productOrder);
           await _dataContext.SaveChangeAsync();
            return productOrder;
        }

        public async Task Delete(Order productOrder)
        {
            _dataContext.Orders.Remove(productOrder);
            await _dataContext.SaveChangeAsync();
        }

        public async Task<Order> Get(int id) => await _dataContext.Orders
            .Include(c => c.CustomerPersonalData)
            .ThenInclude(customerData => customerData.CustomerAddress)
            .Include(p => p.OrderedProducts)
            .Include(d=>d.DeliveryOption)
            .FirstOrDefaultAsync(x=>x.ProductOrderId==id);


        public async Task<IEnumerable<Order>> Get()
        => await _dataContext.Orders.Include(c=>c.CustomerPersonalData)
            .ThenInclude(customerData => customerData.CustomerAddress)
            .Include(p=>p.OrderedProducts)
            .Include(d=>d.DeliveryOption)
            .ToListAsync();

        public async Task Update(Order productOrder)
        {
            await _dataContext.SaveChangeAsync();
        }
    }
}
