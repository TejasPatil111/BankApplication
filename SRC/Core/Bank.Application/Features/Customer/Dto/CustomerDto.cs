using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Bank.Domain.Enums;

namespace Bank.Application.Features.Customer.Dto
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool KeyStatus { get; set; }
        public CustomerStaus Status { get; set; }
        public DateTime CreatedOnUtc { get; set; }
    }
}
