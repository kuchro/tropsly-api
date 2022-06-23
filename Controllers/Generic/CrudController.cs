using Microsoft.AspNetCore.Mvc;
using tropsly_api.Model;
using tropsly_api.Repository;

namespace tropsly_api.Controllers
{
    /*[ApiController]
    [Route("api/[controller]")]*/
    public class CrudController<T>: ControllerBase where T: class 
    {
        protected readonly ICrudRepository<T> _crudRepository;

        public CrudController(ICrudRepository<T> crudRepository)
        {
            _crudRepository=crudRepository;
        }


        //[HttpGet("{id}")]
        public async Task<ActionResult<T>> GetById(int id)
        {
            return await _crudRepository.Get(id);
        }

        //[HttpGet]
        public async Task<ActionResult<IEnumerable<T>>> Get()
        {
            var products = await _crudRepository.Get();
            return Ok(products);
        }

       // [HttpPost]
        public async Task<ActionResult<T>> Create([FromBody] T t)
        {
            var entity = await _crudRepository.Create(t);
            return Ok(entity);
        }

    }
}
