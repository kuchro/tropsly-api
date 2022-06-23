using Microsoft.AspNetCore.Mvc;
using tropsly_api.Model;
using tropsly_api.Model.Dto;
using tropsly_api.Model.Dto.Request;
using tropsly_api.Repository;

namespace tropsly_api.Controllers
{
    [ApiController]
    [Route("v1/api/product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly IUserRepository _userRepository;

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository, IBrandRepository brandRepository, IUserRepository userRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _brandRepository = brandRepository;
            _userRepository = userRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            return await _productRepository.Get(id);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            var products = await _productRepository.GetAll();
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct(CreateProductRequest productRequest)
        {
            var cat = await _categoryRepository.GetByName(productRequest.Category);
            var brand = await _brandRepository.GetByName(productRequest.Brand);
            //  var userData = await _userRepository.GetById(productRequest.UserId);

            if (cat != null && brand != null)
            {
                var product = new Product
                {
                    Title = productRequest.Title,
                    Description = productRequest.Description,
                    Price = productRequest.Price,
                    Image = productRequest.Image,
                    DateCreated = DateTime.Now,
                    Category = cat,
                    Quantity = productRequest.Quantity,
                    Material = productRequest.Material,
                    // CreatedByUserId = productRequest.UserId,
                    Brand = brand,
                    Size = productRequest.Size
                };
                await _productRepository.Add(product);
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("category/{id:int}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByCategory([FromRoute] int id)
        {
            var products = await _productRepository.GetAll();
            return Ok(products.Where(product => product.CategoryId == id));
        }

        

        [HttpPut("{id:int}")]
        public async Task UpdateProduct(int id, UpdateProductRequest productRequest)
        {
            try
            {
                await _productRepository.Update(id, productRequest);
            }
            catch (Exception)
            {

            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            await _productRepository.Delete(id);
            return Ok();
        }
    }
}
