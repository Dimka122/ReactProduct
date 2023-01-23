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
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var villainById = await _productContext
            .SuperVillain.Where(_ => _.Id == id)
            .FirstOrDefaultAsync();
            return Ok(villainById);
        }
        [HttpPut]
        public async Task<IActionResult> Put(SuperVillain villainToUpdate)
        {
            _productContext.SuperVillain.Update(villainToUpdate);
            await _productContext.SaveChangesAsync();
            return Ok(villainToUpdate);
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var villainToDelete = await _productContext.SuperVillain.FindAsync(id);
            if (villainToDelete == null)
            {
                return NotFound();
            }
            _productContext.SuperVillain.Remove(villainToDelete);
            await _productContext.SaveChangesAsync();
            return Ok();
        }
    }
}
