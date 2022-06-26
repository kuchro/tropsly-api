using Microsoft.EntityFrameworkCore;
using tropsly_api.Data;
using tropsly_api.Model.OrderData;

namespace tropsly_api.Repository.ProductOrderRepo
{
    public class CustomerAddressRepository : ICustomerAddressRepository
    {
        private readonly IDataContext _dataContext;
        public CustomerAddressRepository(IDataContext dataContext)
        {
            this._dataContext = dataContext;
        }
        public async Task<CustomerAddress> Add(CustomerAddress productOrder)
        {
            _dataContext.CustomerAddresses.Add(productOrder);
           await _dataContext.SaveChangeAsync();
           return productOrder;
        }

        public async Task Delete(CustomerAddress productOrder)
        {
            _dataContext.CustomerAddresses.Remove(productOrder);
            await _dataContext.SaveChangeAsync();
        }

        public async Task<CustomerAddress> GetByCustomerId(int id) => await _dataContext.CustomerAddresses.FirstOrDefaultAsync(x=>x.CustomerId==id);


        public async Task<IEnumerable<CustomerAddress>> Get()
        => await _dataContext.CustomerAddresses.ToListAsync();

        public Task Update(CustomerAddress productOrder)
        {
            throw new NotImplementedException();
        }
    }
}
