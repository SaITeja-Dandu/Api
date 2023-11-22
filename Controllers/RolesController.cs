using Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly MyDbContext _context;

        public RolesController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<UserRole>> Get()
        {
            return await _context.userRoles.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 1)
                return BadRequest();
            var roles = await _context.userRoles.FirstOrDefaultAsync(m => m.Id == id);
            if (roles == null)
                return NotFound();

            return Ok(roles);

        }

        [HttpPost]
        public async Task<IActionResult> Post(UserRole role)
        {
            if (role == null)
                return BadRequest();
            _context.Add(role);
            await _context.SaveChangesAsync();  
            return Ok();

        }
        [HttpPut]
        public async Task<IActionResult> Put(UserRole RolePut)
        {
            if (RolePut == null || RolePut.Id==0)
                return BadRequest();
            var roles = await _context.userRoles.FindAsync(RolePut.Id);

                if (roles == null)
                return NotFound();

            roles.RoleID = RolePut.RoleID;
            roles.RoleName = RolePut.RoleName;
            roles.RoleDescription= RolePut.RoleDescription;
            roles.IsActived=    RolePut.IsActived;
            roles.InsertDate = RolePut.InsertDate;
            roles.UpdateDate = RolePut.UpdateDate;
            roles.UpdatedBy = RolePut.UpdatedBy;

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1 )
                return BadRequest();
            var roles = await _context.userRoles.FindAsync(id);
            if(roles == null)
                return NotFound();
             _context.Remove(roles);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
