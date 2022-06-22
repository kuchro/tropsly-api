using Microsoft.EntityFrameworkCore;
using tropsly_api.Data;
using tropsly_api.Model.ConfigData;

namespace tropsly_api.Repository.Category
{
    public class DeliveryOptionRepository : IDeliveryOptionRepository
    {
        private readonly IDataContext _context;

        public DeliveryOptionRepository(IDataContext context)
        {
            _context = context;
        }
        public async Task Add(DeliveryOption deliveryOption)
        {
            _context.DeliveryOptions.Add(deliveryOption);
            await _context.SaveChangeAsync();
        }

        public async Task<DeliveryOption> Get(int id)
        => await _context.DeliveryOptions.FindAsync(id);

        public async Task<IEnumerable<DeliveryOption>> GetAll() 
            => await _context.DeliveryOptions.ToListAsync();


    }
}
