using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proj.Models;
using Microsoft.EntityFrameworkCore;

namespace Proj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperVillainController : ControllerBase
    {
        private readonly ProductContext _productContext;
        public SuperVillainController(ProductContext productContext)
        {
            _productContext = productContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var villains = await _productContext.SuperVillain.ToListAsync();
            return Ok(villains);
        }
        [HttpPost]
        public async Task<IActionResult> Post(SuperVillain newSuperVillain)
        {
            _productContext.SuperVillain.Add(newSuperVillain);
            await _productContext.SaveChangesAsync();
            return Ok(newSuperVillain);
        }
    }
}
