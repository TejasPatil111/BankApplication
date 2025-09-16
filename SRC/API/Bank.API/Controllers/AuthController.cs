using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Bank.Application.Dto.Auth;
using Bank.Domain.Entities;
using Bank.Infrastructure;
using Microsoft.AspNetCore.Http;
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
            var loginuser = _context.Customers.FirstOrDefault(c => c.Email == logindto.Email && c.Password == logindto.Password);
            if (loginuser == null)
            {
                return Unauthorized("Incorrect Email or Password");
            }
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_cofig["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, logindto.Email)
            };
            var token = new JwtSecurityToken(
                issuer: _cofig["Jwt:Issuer"],
                audience: _cofig["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
                );

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(jwtToken);

        }


        [HttpPost("[action]")]
        public IActionResult Register([FromBody] Customer registerUser)
        {
            var regUser = _context.Customers.Add(registerUser);
            if (_context.SaveChanges() < 0)
            {
                return Unauthorized("Failed registering");
            }
            return Ok("Registered Successfully!");

        }

    }
}



