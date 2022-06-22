using Microsoft.EntityFrameworkCore;
using tropsly_api.Data;
using tropsly_api.Model.UserAccess;


namespace tropsly_api.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IDataContext _dataContext;

        public UserRepository(IDataContext dataContext)
        {
            _dataContext=dataContext; 
        }

        public async Task<User> GetById(int id) => await _dataContext.Users.FindAsync(id);

        public async Task<User> AddUser(User user)
        {
            var userData = _dataContext.Users.Add(user);
            await _dataContext.SaveChangeAsync();
            return userData.Entity;
        }

        public async Task<IEnumerable<User>> GetUsers() => await _dataContext.Users.ToListAsync();
    }
}
