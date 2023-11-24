using Api.Models.FarmerNew;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers.NewFarmer
{
    [Route("api/[controller]")]
    [ApiController]
    public class CultivationController : ControllerBase
    {
        private readonly MyDbContext _context;

        public CultivationController(MyDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddCultivation([FromBody] Cultivation cultivation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.F_Cultivation.Add(cultivation);
            await _context.SaveChangesAsync();

            return Ok(cultivation);
        }

        [HttpGet]
        public async Task<IActionResult> GetCultivations()
        {
            var cultivations = await _context.F_Cultivation.ToListAsync();
            return Ok(cultivations);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCultivation([FromBody] Cultivation cultivation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.F_Cultivation.Update(cultivation);
            await _context.SaveChangesAsync();

            return Ok(cultivation);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCultivation(int id)
        {
            var cultivation = await _context.F_Cultivation.FindAsync(id);
            if (cultivation == null)
            {
                return NotFound();
            }

            _context.F_Cultivation.Remove(cultivation);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
