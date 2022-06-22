using Microsoft.AspNetCore.Mvc;
using tropsly_api.Model.UserAccess;

namespace tropsly_api.Repository
{
    public interface IAddressRepository
    {
        public Task<ActionResult<int>> Add(Address address);
    }
}
