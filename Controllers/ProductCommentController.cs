using Microsoft.AspNetCore.Mvc;
using tropsly_api.Model;
using tropsly_api.Model.Dto;
using tropsly_api.Model.Dto.Request;
using tropsly_api.Model.Dto.Response;
using tropsly_api.Repository;

namespace tropsly_api.Controllers
{
    [ApiController]
    [Route("v1/api/product/comment")]
    public class ProductCommentController : ControllerBase
    {
        private readonly ICommentSectionRepository _commentRepository;
        private readonly IProductRepository _productRepository;

        public ProductCommentController(ICommentSectionRepository commentSection, IProductRepository productRepository)
        {
            this._commentRepository=commentSection;
            this._productRepository=productRepository;
        }


        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<IEnumerable<CommentSection>>> GetAllCommentsFor([FromRoute] int id)
        {
            var comments = await _commentRepository.GetAllByProductId(id);
           
            return Ok(comments.Select(x => DataMapper.ToResponse(x)).ToList().OrderByDescending(x=> x.DateTime));
        }

        [HttpPost]
        public async Task<ActionResult> CreateComment(CommentRequest commentReq)
        {
            var productData  = await _productRepository.Get(commentReq.ProductId);
            var comment = new CommentSection
            {
                Comment = commentReq.Comment,
                CreatedDate = DateTime.Now,
                ProductId = commentReq.ProductId,
                Product =productData
                
            };
            await _commentRepository.Add(comment);
            return Ok();
        }

    }
}
