using Microsoft.EntityFrameworkCore;
using tropsly_api.Data;
using tropsly_api.Model.OrderData;

namespace tropsly_api.Repository.ProductOrderRepo
{
    public class OrderedProductRepository : IOrderedProductRepository
    {
        private readonly IDataContext _dataContext;
        public OrderedProductRepository(IDataContext dataContext)
        {
            this._dataContext = dataContext;
        }
        public async Task<int> Add(OrderedProduct productOrder)
        {
            _dataContext.OrderedProducts.Add(productOrder);
            await _dataContext.SaveChangeAsync();
            return productOrder.ProductId;
        }

        public async Task Delete(OrderedProduct productOrder)
        {
            _dataContext.OrderedProducts.Remove(productOrder);
            await _dataContext.SaveChangeAsync();
        }

        public async Task<OrderedProduct> Get(int id) => await _dataContext.OrderedProducts.FindAsync(id);


        public async Task<IEnumerable<OrderedProduct>> Get()
        => await _dataContext.OrderedProducts.ToListAsync();

        public Task Update(OrderedProduct productOrder)
        {
            throw new NotImplementedException();
        }
    }
}
