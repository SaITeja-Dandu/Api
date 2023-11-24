using Api.Models.FarmerNew;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers.NewFarmer
{
    [Route("api/[controller]")]
    [ApiController]
    public class LandController : ControllerBase
    {
        private readonly MyDbContext _context;

        public LandController(MyDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddLand([FromBody] Land land)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.F_Land.Add(land);
            await _context.SaveChangesAsync();

            return Ok(land);
        }

        [HttpGet]
        public async Task<IActionResult> GetLands()
        {
            var lands = await _context.F_Land.ToListAsync();
            return Ok(lands);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLand([FromBody] Land land)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.F_Land.Update(land);
            await _context.SaveChangesAsync();

            return Ok(land);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteLand(int id)
        {
            var land = await _context.F_Land.FindAsync(id);
            if (land == null)
            {
                return NotFound();
            }

            _context.F_Land.Remove(land);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }

}
