using Api.Models.FarmerNew;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers.NewFarmer
{
    [Route("api/[controller]")]
    [ApiController]
    public class WateringController : ControllerBase
    {
        private readonly MyDbContext _context;

        public WateringController(MyDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddWatering([FromBody] Watering watering)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.F_Watering.Add(watering);
            await _context.SaveChangesAsync();

            return Ok(watering);
        }

        [HttpGet]
        public async Task<IActionResult> GetWateringsByCultivationId(int cultivationId)
        {
            var waterings = await _context.F_Watering.Where(w => w.CultivationId == cultivationId).ToListAsync();
            return Ok(waterings);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateWatering([FromBody] Watering watering)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.F_Watering.Update(watering);
            await _context.SaveChangesAsync();

            return Ok(watering);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteWatering(int id)
        {
            var watering = await _context.F_Watering.FindAsync(id);
            if (watering == null)
            {
                return NotFound();
            }

            _context.F_Watering.Remove(watering);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }

}
