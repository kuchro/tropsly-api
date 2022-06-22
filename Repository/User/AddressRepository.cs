using Microsoft.AspNetCore.Mvc;
using tropsly_api.Data;
using tropsly_api.Model.UserAccess;

namespace tropsly_api.Repository
{
    public class AddressRepository : IAddressRepository
    {

        private readonly IDataContext _context;

        public AddressRepository(IDataContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<int>> Add(Address address)
        {
            var addressData  = _context.Address.Add(address);
            await _context.SaveChangeAsync();
            return addressData.Entity.AddressId;
        }
    }
}
