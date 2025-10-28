using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Bank.Domain.Enums;

namespace Bank.Application.Features.Account.Dtos
{
    public class CheckBalanceDto
    {
        public int AccountId { get; set; }
        public string? AccountNo { get; set; }
        public string? CustomerName { get; set; }
        public int? AccountType { get; set; }
        public decimal Balance { get; set; }
    }
}
