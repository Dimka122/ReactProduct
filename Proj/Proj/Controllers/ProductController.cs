using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            if (_productContext == null)
            {
                return NotFound();
            }
            return await _productContext.ProductList.ToListAsync();
        }

        //GET : api/product/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductd(Guid id)
        {
            if (_productContext == null)
            {
                return NotFound();
            }

            var product = await _productContext.ProductList.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> UpdateProduct(Guid id, Product product)
        {
            if (product.Id != id)
            {
                return BadRequest();
            }

            _productContext.Entry(product).State = EntityState.Modified;

            await _productContext.SaveChangesAsync();

            var updatedProduct = _productContext.ProductList.FirstOrDefaultAsync(x => x.Id == id);

            return product;
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var product = await _productContext.ProductList.FindAsync(id);

            if (product == null) return NotFound();

            _productContext.ProductList.Remove(product);

            await _productContext.SaveChangesAsync();

            return NoContent();

        }
    }
}
