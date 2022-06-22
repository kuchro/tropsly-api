using Microsoft.EntityFrameworkCore;
using tropsly_api.Data;
using tropsly_api.Model;
using tropsly_api.Model.Dto.Response;

namespace tropsly_api.Repository
{
    public class RatingDataRepository : IRatingDataRepository
    {
        private readonly IDataContext _dataContext;

        public RatingDataRepository(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<RatingAvgResponse> GetProductRate(int id)
        {
            var ratingData = await _dataContext.RatingData.Where(x=>x.ProductId==id).ToListAsync();

            var avgRating = Math.Round(ratingData.Select(x=>x.RatingScore).ToList().Average(),2);

            return new RatingAvgResponse { ProductId = id, RatingAvg = avgRating, VoteNumber=ratingData.Count };
        }

        public async Task RateProduct(RatingData rate)
        {
            _dataContext.RatingData.Add(rate);
            await _dataContext.SaveChangeAsync();
        }
    }
}
