using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        private readonly IProductTypeRepository _repo;
        public ProductTypeController(IProductTypeRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductType>>> GetProductTypes()
        {
            var productTypes = await _repo.ListAllAsync();
            return Ok(productTypes);
        }
    }
}
