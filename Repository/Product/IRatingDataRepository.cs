using tropsly_api.Model;
using tropsly_api.Model.Dto.Response;

namespace tropsly_api.Repository
{
    public interface IRatingDataRepository
    {
        Task RateProduct(RatingData rate);
        Task<RatingAvgResponse> GetProductRate(int rate);
    }
}
