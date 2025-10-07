using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Infrastructure.PasswordHelpers
{
    public class PasswordHelper
    {
        public static string HashPassword(string password)
        {
            // Implement a simple hashing mechanism (for demonstration purposes only)
            // In a real-world application, use a secure hashing algorithm like BCrypt or Argon2
            var bytes = System.Text.Encoding.UTF8.GetBytes(password);
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
    }
}
