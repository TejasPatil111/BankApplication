using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Bank.Application.Dto.Auth;
using Bank.Domain;
using Bank.Domain.Entities;
using Bank.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Bank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        BankDbContext _context;

        private readonly IConfiguration _cofig;

        public AuthController(IConfiguration cofig, BankDbContext context)
        {
            _cofig = cofig;
            _context = context;
        }
        [HttpPost("[action]")]
        public IActionResult Login([FromBody] LoginDto logindto)
        {
            if (logindto == null || string.IsNullOrWhiteSpace(logindto.Email) || string.IsNullOrWhiteSpace(logindto.Password))
            {
            return BadRequest("Invalid login request");
            }
            var loginuser = _context.Customers.FirstOrDefault(c => c.Email == logindto.Email );
            if (loginuser == null)
            {
                return Unauthorized("Incorrect Email or Password");
            }
            //verify hashed password
            var hash = new PasswordHasher<Customer>();
            var result = hash.VerifyHashedPassword(loginuser, loginuser.Password, logindto.Password);
            



            //genrate JWT token
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_cofig["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, logindto.Email),
                new Claim("CustomerId",loginuser.id.ToString())
            };
            var token = new JwtSecurityToken(
                issuer: _cofig["Jwt:Issuer"],
                audience: _cofig["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
                );

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(new { jwtToken }   );

        }


        [HttpPost("[action]")]
        public IActionResult Register([FromBody] Customer registerUser)
        {
            if (registerUser == null || string.IsNullOrWhiteSpace(registerUser.Password))
                return BadRequest("Invalid registatrion Data.");

            //Hash pass before saving
            var hasher = new PasswordHasher<Customer>();
            registerUser.Password = hasher.HashPassword(registerUser, registerUser.Password);
            registerUser.id = 0; 
            registerUser.CreatedOnUtc = DateTime.UtcNow;
            registerUser.Status = Enums.CustomerStaus.Active;
            registerUser.KeyStatus = true;

            _context.Customers.Add(registerUser);

            if (_context.SaveChanges() <= 0)
            {
                return Unauthorized("Registartion failed");

            }
            return Ok("Registerd Successfully");
        }

    }
}



