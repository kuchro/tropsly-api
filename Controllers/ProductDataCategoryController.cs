using Microsoft.AspNetCore.Mvc;
using tropsly_api.Model.ConfigData;
using tropsly_api.Model.Dto;
using tropsly_api.Model.Dto.Request;
using tropsly_api.Model.Dto.Response;
using tropsly_api.Repository;
using tropsly_api.Repository.Category;

namespace tropsly_api.Controllers
{
    [ApiController]
    [Route("v1/api/configure/")]
    public class ProductDataCategoryController : ControllerBase
    {
        private readonly ICrudRepository<Category> _categoryRepository;
        private readonly ICrudRepository<Brand> _brandRepository;
        private readonly IDeliveryOptionRepository _deliveryOption;
        private readonly ICrudRepository<ProductType> _crudProductType;
        private readonly ICrudRepository<MaterialType> _crudMaterialType;
        public ProductDataCategoryController(ICrudRepository<Category> categoryRepository,
            ICrudRepository<Brand> brandRepository, IDeliveryOptionRepository deliveryOptionRepository,
            ICrudRepository<ProductType> crudProductType, ICrudRepository<MaterialType> crudMaterialType)
        {
            _categoryRepository=categoryRepository;
            _brandRepository=brandRepository;
            _deliveryOption=deliveryOptionRepository;
            _crudProductType=crudProductType;
            _crudMaterialType=crudMaterialType;
        }

        [HttpGet("category")]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategories()
        {
            var categories = await _categoryRepository.Get();
            return Ok(categories.Select(x => DataMapper.ToResponse(x)));
        }

        [HttpPost]
        [Route("category")]
        public async Task<ActionResult> CreateCategory([FromBody] List<string> categoryRequest)
        {
            IList<Category> categories = new List<Category>();
            categoryRequest.ForEach(name => categories.Add(new Category
            {
                Name = name,
                CreatedDateTime = DateTime.Now
            }));
         
            await _categoryRepository.AddCollection(categories);
            return Ok();
        }

    
        [HttpDelete]
        [Route("category/remove")]
        public async Task DeltetCategories([FromBody] List<string> categories)
        {

            var allBrands = await _categoryRepository.Get();
            var selectedToDelete = allBrands.Where(x => categories.Any(data => data == x.Name)).ToList();
            await _categoryRepository.DeleteCollection(selectedToDelete);

        }

        [HttpGet]
        [Route("brand")]
        public async Task<ActionResult<IEnumerable<ConfigDataResponse>>> GetAllBrands()
        {
            var brands = await _brandRepository.Get();
            return Ok(brands.Select(x=> DataMapper.ToResponse(x)));
        }

        [HttpPost]
        [Route("brand")]
        public async Task<ActionResult> CreateBrand([FromBody] List<string> names)
        {
            IList<Brand> brands = new List<Brand>();
            names.ForEach(name => brands.Add(new Brand
            {
                Name = name,
                CreatedDateTime = DateTime.Now
            }));
            await _brandRepository.AddCollection(brands);
            return Ok();
        }

     

        [HttpDelete]
        [Route("brand/remove")]
        public async Task DeltetBrands([FromBody] List<string> brands)
        {
            var allBrands = await _brandRepository.Get();
            var selectedToDelete = allBrands.Where(x=> brands.Any(data => data==x.Name)).ToList();
            await _brandRepository.DeleteCollection(selectedToDelete);

        }

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<IEnumerable<dynamic>>> GetAllConfigs()
        {
            var brands = await _brandRepository.Get();
            var category = await _categoryRepository.Get();
            var prodType = await _crudProductType.Get();
            var materialType = await _crudMaterialType.Get();
            var arr  = new Dictionary<string,dynamic>();
            arr.Add("brand",brands.Select(x => DataMapper.ToResponse(x)));
            arr.Add("category",category.Select(x => DataMapper.ToResponse(x)));
            arr.Add("product-type", prodType.Select(x => DataMapper.ToResponse(x)));
            arr.Add("material-type", materialType.Select(x => DataMapper.ToResponse(x)));
            return Ok(arr);
        }


        [HttpPost]
        [Route("delivery")]
        public async Task<ActionResult> CreateDelivery(DeliveryOptionRequest deliveryOption)
        {
            var data = new DeliveryOption
            {
                DeliveryName = deliveryOption.DeliveryName,
                DeliveryPrice = deliveryOption.DeliveryPrice,
                ExtraOptions = deliveryOption.ExtraOptions,
                CreatedDateTime = DateTime.Now
            };
            await _deliveryOption.Add(data);
            return Ok();
        }

        [HttpGet]
        [Route("delivery")]
        public async Task<ActionResult<IEnumerable<DeliveryOptionsResponse>>> GetAllDeliveryOptions()
        {
            var deliveryOptions = await _deliveryOption.GetAll();
            return Ok(deliveryOptions.Select(x => DataMapper.ToResponse(x)));
        }


        [HttpDelete("delivery/{id}")]
        public async Task<ActionResult> DeleteDeliveryOption(int id)
        {
            await _deliveryOption.Delete(id);
            return Ok();
        }


        [HttpPut("delivery")]
        public async Task UpdateProduct(DeliveryOption newData)
        {
           await _deliveryOption.Update(newData);
        }



        [HttpPost]
        [Route("product-type")]
        public async Task<ActionResult> CreateProductType([FromBody] List<string> categoryRequest)
        {


            IList<ProductType> dataList = new List<ProductType>();
            categoryRequest.ForEach(name => dataList.Add(new ProductType
            {
                Name = name,
                CreatedDateTime = DateTime.Now
            }));    
            await _crudProductType.AddCollection(dataList);
            return Ok();
        }

        [HttpGet]
        [Route("product-type")]
        public async Task<ActionResult<IEnumerable<ConfigDataResponse>>> GetAllProductType()
        {
            var data = await _crudProductType.Get();
            return Ok(data.Select(x => DataMapper.ToResponse(x)));
        }


        [HttpDelete("product-type/remove")]
        public async Task<ActionResult> DeleteProductType([FromBody] List<string> dataReq)
        {
            var allTypes = await _crudProductType.Get();
            var selectedToDelete = allTypes.Where(x => dataReq.Any(data => data == x.Name)).ToList();
            await _crudProductType.DeleteCollection(selectedToDelete);
            return Ok();
        }

        [HttpPost]
        [Route("material-type")]
        public async Task<ActionResult> CreateMaterialType([FromBody] List<string> categoryRequest)
        {
            IList<MaterialType> dataList = new List<MaterialType>();
            categoryRequest.ForEach(name => dataList.Add(new MaterialType
            {
                Name = name,
                CreatedDateTime = DateTime.Now
            }));
            await _crudMaterialType.AddCollection(dataList);
            return Ok();
        }

        [HttpGet]
        [Route("material-type")]
        public async Task<ActionResult<IEnumerable<ConfigDataResponse>>> GetAllMaterialType()
        {
            var data = await _crudMaterialType.Get();
            return Ok(data.Select(x => DataMapper.ToResponse(x)));
        }


        [HttpDelete("material-type/remove")]
        public async Task<ActionResult> DeleteMaterialType(List<string> dataReq)
        {
            var allTypes = await _crudMaterialType.Get();
            var selectedToDelete = allTypes.Where(x => dataReq.Any(data => data == x.Name)).ToList();
            await _crudMaterialType.DeleteCollection(selectedToDelete);
            return Ok();
        }

    }
}
