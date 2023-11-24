using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api.Models.FarmerNew;


namespace Api.Controllers.NewFarmer
{
    [Route("api/[controller]")]
    [ApiController]
    public

class

UserController : ControllerBase
    {
        private

    readonly MyDbContext _context;

        public

    UserController(MyDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public

    async Task<IActionResult> Register([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.F_User.Add(user);


            await _context.SaveChangesAsync();

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            var existingUser =  _context.F_User.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
            if (existingUser == null)
            {
                return Unauthorized();
            }

            return Ok(existingUser);
        }
    }
}
