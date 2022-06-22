using Microsoft.AspNetCore.Mvc;
using tropsly_api.Model.Dto;
using tropsly_api.Model.Dto.Request;
using tropsly_api.Model.Dto.Response;
using tropsly_api.Repository;

namespace tropsly_api.Controllers
{
    [ApiController]
    [Route("v1/api/product/rate")]
    public class RatingController : ControllerBase
    {
        private readonly IRatingDataRepository _ratingDataRepository;

        public RatingController(IRatingDataRepository ratingDataRepository)
        {
            _ratingDataRepository = ratingDataRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RatingAvgResponse>> GetProductAvgRating(int id)
        {
            return await _ratingDataRepository.GetProductRate(id);
        }

        [HttpPost]
        public async Task<ActionResult> RateProduct(RateProductRequest rateProductRequest)
        {
            var rateData = DataMapper.ToModel(rateProductRequest);
            await _ratingDataRepository.RateProduct(rateData);
            return Ok();
        }
    }
}
