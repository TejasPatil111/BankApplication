using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.Features.Account.Dtos
{
    public class AccountDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Account { get; set; }
        public int AccountType { get; set; }
        public int Status { get; set; }
        public decimal Balance { get; set; }
        public string Currency { get; set; }
        public DateTime OpendOnUtc { get; set; }
        public DateTime? ClosedOnUtc { get; set; }
        public string RowVersion { get; set; }
    }
}
