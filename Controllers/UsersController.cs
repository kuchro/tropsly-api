using Microsoft.AspNetCore.Mvc;
using tropsly_api.Model.UserAccess;
using tropsly_api.Model.UserAccess.Dto;
using tropsly_api.Repository;

namespace tropsly_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IAddressRepository _addressRepository;
        public UsersController(IUserRepository userRepository, IAddressRepository addressRepository)
        {
            this._userRepository=userRepository;
            this._addressRepository=addressRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _userRepository.GetUsers();
            return Ok(users);

        }

        // POST: api/users/register
        [HttpPost("RegisterUser")]
        public async Task<ActionResult<User>> RegisterUser([FromBody] RegisterRequest register)
        {
            var addres = new Address
            {
                StreetName = register.Address.StreetName,
                City = register.Address.City,
                State = register.Address.State,
                FlatNumber = register.Address.FlatNumber
            };
            var addressId = await _addressRepository.Add(addres);
            var userData = new User
            {
                FirstName = register.FirstName,
                LastName = register.LastName,
                Password = register.Password,
                PhoneNumber = register.PhoneNumber,
                EmailAddress = register.EmailAddress,
                Gender = register.Gender,
                AddressId = addressId.Value,
                RoleId =1
                
            };

            var addedUser = await _userRepository.AddUser(userData);
            return Ok(addedUser);
        }
    }
}
