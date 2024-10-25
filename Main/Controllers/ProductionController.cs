using Main.Application.Factory;
using Main.Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Main.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public IBusinessHandlersFactory _businessHandlers;
        public ProductController(IBusinessHandlersFactory businessHandlers)
        {
            _businessHandlers = businessHandlers;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            var products = _businessHandlers.Product.GetOne();
            return Ok(products);
        }
    }
}
