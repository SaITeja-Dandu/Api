using Api.Models.FarmerNew;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers.NewFarmer
{
    [Route("api/[controller]")]
    [ApiController]
    public class PesticideController : ControllerBase
    {
        private readonly MyDbContext _context;

        public PesticideController(MyDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddPesticide([FromBody] Pesticide pesticide)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.F_Pesticide.Add(pesticide);
            await _context.SaveChangesAsync();

            return Ok(pesticide);
        }

        [HttpGet]
        public async Task<IActionResult> GetPesticides()
        {
            var pesticides = await _context.F_Pesticide.ToListAsync();
            return Ok(pesticides);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePesticide([FromBody] Pesticide pesticide)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.F_Pesticide.Update(pesticide);
            await _context.SaveChangesAsync();

            return Ok(pesticide);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePesticide(int id)
        {
            var pesticide = await _context.F_Pesticide.FindAsync(id);
            if (pesticide == null)
            {
                return NotFound();
            }

            _context.F_Pesticide.Remove(pesticide);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }

}
