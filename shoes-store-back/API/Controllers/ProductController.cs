using API.DAO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/product")]
    public class ProductController : Controller
    {
        private readonly ProductDAO dao;
        public ProductController(ProductDAO dao) { 
            this.dao = dao;
        }

        [HttpGet("get-products")]
        public IActionResult GetProducts()
        {
            var response = dao.GetProducts();
            return Ok(response);
        }
    }
}
