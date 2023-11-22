using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Threading.Tasks;
using Api.Models;
using Microsoft.EntityFrameworkCore;
using Azure;
using Microsoft.Net.Http.Headers;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagementController : ControllerBase
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly MyDbContext _context;

        public UserManagementController(MyDbContext context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;
        }

        [HttpGet]
        public async Task<IEnumerable<UserManagement>> Get()
        {
            return await _context.userManagements.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 1)
                return BadRequest();
            var user = await _context.userManagements.FirstOrDefaultAsync(m => m.Id == id);

            if (user == null)
                return NotFound();
            return Ok(user);
        }
        [HttpPost]
        public async Task<IActionResult> Post(UserManagement users)
        {
            if (users == null)
                return BadRequest();
            _context.Add(users);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Put(UserManagement usersData)
        {
            if (usersData == null || usersData.Id == 0)
                return BadRequest();
            var users = await _context.userManagements.FindAsync(usersData.Id);
            if (users == null)
                return NotFound();
            users.UserName = usersData.UserName;
            users.Password = usersData.Password;
            users.FirstName = usersData.FirstName;
            users.LastName = usersData.LastName;
            users.MobileNo = usersData.MobileNo;
            users.InsertDate = usersData.InsertDate;
            users.UpdateDate = usersData.UpdateDate;
            users.UpdatedBy = usersData.UpdatedBy;
            
            await _context.SaveChangesAsync();

            return Ok();
            
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1 )
                return BadRequest();
            var users = await _context.userManagements.FindAsync(id);
            if (users == null)
                return NotFound();
            _context.userManagements.Remove(users);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
