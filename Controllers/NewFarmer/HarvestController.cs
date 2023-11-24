using Api.Models.FarmerNew;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers.NewFarmer
{
    [Route("api/[controller]")]
    [ApiController]
    public class HarvestController : ControllerBase
    {
        private readonly MyDbContext _context;

        public HarvestController(MyDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddHarvest([FromBody] Harvest harvest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.F_Harvest.Add(harvest);
            await _context.SaveChangesAsync();

            return Ok(harvest);
        }

        [HttpGet]
        public async Task<IActionResult> GetHarvests()
        {
            var harvests = await _context.F_Harvest.ToListAsync();
            return Ok(harvests);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateHarvest([FromBody] Harvest harvest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.F_Harvest.Update(harvest);
            await _context.SaveChangesAsync();

            return Ok(harvest);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteHarvest(int id)
        {
            var harvest = await _context.F_Harvest.FindAsync(id);
            if (harvest == null)
            {
                return NotFound();
            }

            _context.F_Harvest.Remove(harvest);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }

}
