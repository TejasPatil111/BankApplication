using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Bank.Domain.Enums;

namespace Bank.Domain.Entities
{
    public class Customer
    {
        [Key]
        public int id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string Role { get; set; } = "User";
        public bool KeyStatus { get; set; }
        public CustomerStaus Status { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public string? PasswordResetToken { get; set; }
        public DateTime? TokenExpiry { get; set; }

    }
}
