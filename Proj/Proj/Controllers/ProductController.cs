using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proj.Models;

namespace Proj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductContext _productContext;
        public ProductController(ProductContext productContext)
        {
            _productContext = productContext;
        }
        [HttpPost]
        public async Task<ActionResult<Product>> AddMovie(Product product)
        {
            if (_productContext == null)
            {
                return NotFound();
            }

            _productContext.ProductList.Add(product);

            await _productContext.SaveChangesAsync();

            return product;
        }
    }
}
