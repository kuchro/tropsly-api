using Microsoft.AspNetCore.Mvc;
using tropsly_api.Model;
using tropsly_api.Model.Dto;
using tropsly_api.Model.Dto.Request;
using tropsly_api.Model.Dto.Response;
using tropsly_api.Repository;

namespace tropsly_api.Controllers
{
    [ApiController]
    [Route("v1/api/configure/")]
    public class ProductDataCategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBrandRepository _brandRepository;
        public ProductDataCategoryController(ICategoryRepository categoryRepository, IBrandRepository brandRepository )
        {
            _categoryRepository=categoryRepository;
            _brandRepository=brandRepository;
        }

        [HttpGet("category")]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategories()
        {
            var categories = await _categoryRepository.GetAll();
            return Ok(categories.Select(x => DataMapper.ToResponse(x)));
        }

        [HttpPost]
        [Route("category")]
        public async Task<ActionResult> CreateCategory(CreateProductCatRequest categoryRequest)
        {
            IList<Category> categories = new List<Category>();
            categoryRequest.Names.ToList().ForEach(name => categories.Add(new Category
            {
                Name = name,
                CreatedDateTime = DateTime.Now
            }));
         
            await _categoryRepository.AddCollection(categories);
            return Ok();
        }

        [HttpDelete]
        [Route("category/{name}")]
        public async Task DeleteCategory([FromRoute] string name)
        {

            await _categoryRepository.DeleteByName(name);
       
        }

        [HttpDelete]
        [Route("category/remove")]
        public async Task DeltetCategories([FromBody] List<string> categories)
        {

            var allBrands = await _categoryRepository.GetAll();
            var selectedToDelete = allBrands.Where(x => categories.Any(data => data == x.Name)).ToList();
            await _categoryRepository.DeleteCollection(selectedToDelete);

        }

        [HttpGet]
        [Route("brand")]
        public async Task<ActionResult<IEnumerable<ConfigDataResponse>>> GetAllBrands()
        {
            var brands = await _brandRepository.GetAll();
            return Ok(brands.Select(x=> DataMapper.ToResponse(x)));
        }

        [HttpPost]
        [Route("brand")]
        public async Task<ActionResult> CreateBrand(CreateProductCatRequest categoryRequest)
        {
            IList<Brand> brands = new List<Brand>();
            categoryRequest.Names.ToList().ForEach(name => brands.Add(new Brand
            {
                Name = name,
                CreatedDateTime = DateTime.Now
            }));
            await _brandRepository.AddCollection(brands);
            return Ok();
        }

        [HttpDelete]
        [Route("brand/{name}")]
        public async Task DeleteBrand([FromRoute] string name)
        {
         
            await _brandRepository.DeleteByName(name);
        }

        [HttpDelete]
        [Route("brand/remove")]
        public async Task DeltetBrands([FromBody] List<string> brands)
        {
            var allBrands = await _brandRepository.GetAll();
            var selectedToDelete = allBrands.Where(x=> brands.Any(data => data==x.Name)).ToList();
            await _brandRepository.DeleteCollection(selectedToDelete);

        }

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<IEnumerable<dynamic>>> GetAllConfigs()
        {
            var brands = await _brandRepository.GetAll();
            var category = await _categoryRepository.GetAll();
            var arr  = new Dictionary<string,dynamic>();
            arr.Add("brand",brands.Select(x => DataMapper.ToResponse(x)));
            arr.Add("category",category.Select(x => DataMapper.ToResponse(x)));
            return Ok(arr);
        }


    }
}
