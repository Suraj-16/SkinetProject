using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using skinetAPI.Models;

namespace skinetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _dbcontext;

        public ProductsController(StoreContext context) 
        { 
            _dbcontext = context;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            List<Product> products = new List<Product>();
            products = _dbcontext.Products.ToList();
            return Ok(products );
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            Product product = _dbcontext.Products.SingleOrDefault(p => p.Id == id);
            return Ok(product);
        }
    }
}
