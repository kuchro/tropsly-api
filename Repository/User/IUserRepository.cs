using Microsoft.AspNetCore.Mvc;
using tropsly_api.Model.UserAccess;
using tropsly_api.Model.UserAccess.Dto;

namespace tropsly_api.Repository
{
    public interface IUserRepository
    {
        public Task<User> GetById(int id);
        public Task<User> AddUser(User user);
        public Task<IEnumerable<User>> GetUsers();
    }
}
