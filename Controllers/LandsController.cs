using Api.Models.Farmer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LandsController : ControllerBase
    {
        private readonly MyDbContext _context;

        public LandsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Lands
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Land>>> GetLands()
        {
            return await _context.Land.Include(l => l.User).ToListAsync();
        }

        // GET: api/Lands/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Land>> GetLand(int id)
        {
            var land = await _context.Land.FindAsync(id);

            if (land == null)
            {
                return NotFound();
            }

            return land;
        }

        // PUT: api/Lands/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLand(int id, Land land)
        {
            if (id != land.LandID)
            {
                return BadRequest();
            }

            _context.Entry(land).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LandExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Lands
        [HttpPost]
        public async Task<ActionResult<Land>> PostLand(Land land)
        {
            _context.Land.Add(land);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLand", new { id = land.LandID }, land);
        }

        // DELETE: api/Lands/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLand(int id)
        {
            var land = await _context.Land.FindAsync(id);

            if (land == null)
            {
                return NotFound();
            }

            _context.Land.Remove(land);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LandExists(int id)
        {
            return _context.Land.Any(e => e.LandID == id);
        }
    }

}
