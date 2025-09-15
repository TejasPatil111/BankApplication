using Bank.Application.Dto.Auth;
using Bank.Domain.Entities;
using Bank.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            return Ok("Logged in Successfully!");

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



