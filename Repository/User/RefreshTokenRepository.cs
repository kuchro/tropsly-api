using tropsly_api.Data;

namespace tropsly_api.Repository
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly IDataContext _dataContext;

        public RefreshTokenRepository(IDataContext dataContext)
        {
            _dataContext=dataContext; 
        }
    }
}
