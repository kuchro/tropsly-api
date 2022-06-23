using Microsoft.EntityFrameworkCore;
using tropsly_api.Data;
using tropsly_api.Model.OrderData;

namespace tropsly_api.Repository.ProductOrderRepo
{
    public class CustomerPersonalDataRepository : ICustomerPersonalDataRepository
    {
        private readonly IDataContext _dataContext;
        public CustomerPersonalDataRepository(IDataContext dataContext)
        {
            this._dataContext = dataContext;
        }
        public async Task<CustomerPersonalData> Add(CustomerPersonalData productOrder)
        {
            _dataContext.CustomerPersonalData.Add(productOrder);
            await _dataContext.SaveChangeAsync();
            return productOrder;
        }

        public async Task Delete(CustomerPersonalData productOrder)
        {
            _dataContext.CustomerPersonalData.Remove(productOrder);
            await _dataContext.SaveChangeAsync();
        }

        public async Task<CustomerPersonalData> Get(int id) => await _dataContext.CustomerPersonalData.FindAsync(id);
        public async Task<CustomerPersonalData> GetByOrderId(int id)    
        => await _dataContext.CustomerPersonalData.FirstOrDefaultAsync(x => x.ProductOrderId == id);

        public async Task<IEnumerable<CustomerPersonalData>> Get()
        => await _dataContext.CustomerPersonalData.ToListAsync();

       
        public Task Update(CustomerPersonalData productOrder)
        {
            throw new NotImplementedException();
        }


    }
}
