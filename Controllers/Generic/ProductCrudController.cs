using Microsoft.AspNetCore.Mvc;
using tropsly_api.Model;
using tropsly_api.Repository;

namespace tropsly_api.Controllers
{
    //[ApiController]
    //[Route("v1/api/crud/product")]
    public class ProductCrudController : CrudController<Product>
    {
        public ProductCrudController(ICrudRepository<Product> crudRepository) : base(crudRepository)
        {
        }
 
    }
}
