using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Bank.Application.AuthDto.Auth.Commands;
using Bank.Application.AuthDto.Auth.Dtos;
using Bank.Application.Interfaces;
using Bank.Domain;
using Bank.Domain.Entities;
using Bank.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Bank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        BankDbContext _context;
        private readonly ICustomerRepsitory _repo;
        private readonly IMediator _mediator;
        private readonly IEmailSender _emailSender;
        private readonly ILogger<AuthController> _logger;
        private readonly IConfiguration _cofig;

        //otp settings
        private const int OtpLength = 6;
        private readonly TimeSpan OtpValidity = TimeSpan.FromMinutes(10);

        public AuthController(IConfiguration cofig, BankDbContext context, ICustomerRepsitory repo, IMediator mediator, IEmailSender emailSender, ILogger<AuthController> logger)
        {
            _cofig = cofig;
            _context = context;
            _repo = repo;
            _mediator = mediator;
            _emailSender = emailSender;
            _logger = logger;
        }

        [HttpPost("[action]")]
        public IActionResult Login([FromBody] LoginDto logindto)
        {
            if (logindto == null || string.IsNullOrWhiteSpace(logindto.Email) || string.IsNullOrWhiteSpace(logindto.Password))
            {
                return BadRequest("Invalid login request");
            }
            var loginuser = _context.Customers.FirstOrDefault(c => c.Email == logindto.Email);
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
                new Claim("CustomerRole",loginuser.Role),
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
            return Ok(new { jwtToken });

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
            //registerUser.Role = "User";
            registerUser.CreatedOnUtc = DateTime.UtcNow;
            registerUser.Status = Enums.CustomerStaus.Active;
            registerUser.KeyStatus = true;

            if (string.IsNullOrWhiteSpace(registerUser.Role))
            {
                registerUser.Role = "User";
            }
            _context.Customers.Add(registerUser);

            if (_context.SaveChanges() <= 0)
            {
                return Unauthorized("Registartion failed");

            }
            return Ok(new { message = "Registerd Successfully" });
        }





        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPaswordDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Email))
            {
                return BadRequest(new { error = "Email is required" });
            }

            var customer = await _context.Customers.SingleOrDefaultAsync(c => c.Email == dto.Email.Trim().ToLower());
            if (customer == null)
            {
                return NotFound(new { error = "User Not Found" });
            }

            var rnd = new Random();
            var otpPlain = rnd.Next((int)Math.Pow(10, OtpLength - 1), (int)Math.Pow(10, OtpLength) - 1).ToString();

            //hash Otp before storing
            var otpHashed = BCrypt.Net.BCrypt.HashPassword(otpPlain);
            customer.OtpCode = otpHashed;
            customer.OtpExpiry = DateTime.UtcNow.Add(OtpValidity);
            await _context.SaveChangesAsync();

            var subject = "Password Reset OTP";
            var body = $@"Dear User Your is{otpPlain}
                       <p>This OTP will expire in {OtpValidity.TotalMinutes} minutes.</p>";

            try
            {
                await _emailSender.SendEmailAsync(customer.Email, subject, body);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending OTP email to {Email}", customer.Email);
                customer.OtpCode = null;
                customer.OtpExpiry = null;
                await _context.SaveChangesAsync();
                return StatusCode(500, new { error = "Error sending email. Please try again later." });

            }
            return Ok(new { message = "If the Email Exist , OTP Has Been Sent." });
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Email) || string.IsNullOrWhiteSpace(dto.OtpCode) || string.IsNullOrWhiteSpace(dto.NewPassword))
            {
                return BadRequest(new { error = "Email, OTP and New Password are required" });
            }
            var customer = await _context.Customers.SingleOrDefaultAsync(c => c.Email == dto.Email.Trim().ToLower());
            if (customer == null)
            {
                return NotFound(new { error = "User Not Found" });
            }
            if (customer.OtpCode == null || customer.OtpExpiry == null)
            {
                return BadRequest(new { error = "No OTP Request Found. Please initiate a new password reset request." });
            }
            if (customer.OtpExpiry < DateTime.UtcNow)
            {
                return BadRequest(new { error = "OTP has expired. Please initiate a new password reset request." });
            }
            var isOtpValid = BCrypt.Net.BCrypt.Verify(dto.OtpCode, customer.OtpCode);
            if (!isOtpValid)
            {
                return BadRequest(new { error = "Invalid Otp" });
            }
            var hash = new PasswordHasher<Customer>();
            customer.Password =hash.HashPassword(customer, dto.NewPassword);
            //clear Otp Fields
            customer.OtpCode = null;
            customer.OtpExpiry = null;
            await _context.SaveChangesAsync();
            try
            {
                var subject = "Password Reset Successful";
                var body = "Dear User, Your password has been reset successfully." +
                    " If you did not initiate this change, please contact support immediately.";
                await _emailSender.SendEmailAsync(customer.Email, subject, body);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending password reset confirmation email to {Email}", customer.Email);
            }
            return Ok(new { message = "Password has been reset successfully." });

        }






    }
}




