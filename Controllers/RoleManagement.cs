using Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleManagement : ControllerBase
    {
        private readonly MyDbContext _context;

        public RoleManagement(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var roles = _context.Roles.ToList();

            if (roles == null)
            {
                return NotFound("No data found");
            }

            return Ok(roles);
        }


        [HttpPost]
        public IActionResult Create([FromBody] Role model)
        {
            if (model == null)
            {
                return BadRequest("Invalid data");
            }

            _context.Roles.Add(model);
            _context.SaveChanges();

            return Ok("SUCCESS");
        }
    }
}
