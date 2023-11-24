using Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Cryptography;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase

    {
        private readonly MyDbContext _context;
        private IConfiguration _config;
        public LoginController(IConfiguration config, MyDbContext context)
        {
            _config = config;
            _context = context;
        }

        [HttpPost]
        public IActionResult Post([FromBody] LoginRequest loginRequest)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == loginRequest.username);

            if (user != null && VerifyPassword(user.PasswordHash, loginRequest.password))
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var Sectoken = new JwtSecurityToken(_config["Jwt:Issuer"],
                  _config["Jwt:Issuer"],
                  null,
                  expires: DateTime.Now.AddMinutes(120),
                  signingCredentials: credentials);

                var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);

                return Ok(token);
            }
            else
            {
                // Authentication failed.
                return Unauthorized();
            }
        }
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterRequest registerRequest)
        {
            // Check if the username is already in use
            if (_context.Users.Any(u => u.Username == registerRequest.Username))
            {
                return BadRequest("Username is already taken.");
            }

            string passwordHash = HashPassword(registerRequest.Password);

            // Create a new user and add it to the database
            var user = new User
            {
                Username = registerRequest.Username,
                PasswordHash = passwordHash
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok("Registration successful.");
        }

        private bool VerifyPassword(string storedPasswordHash, string providedPassword)
        {
            string providedPasswordHash = HashPassword(providedPassword);
            return storedPasswordHash == providedPasswordHash;
        }
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }

    }
}
