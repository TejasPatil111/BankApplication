using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Bank.Domain.Enums;

namespace Bank.Domain.Entities
{
    public class Money
    {
        public int Id { get; set; }
        public int FromAccountId { get; set; }
        public int ToAccountId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; } = "INR";
        public TransferStatus Status { get; set; }
        public DateTime InitiatedOnUtc { get; set; }
        public DateTime CompletedOnUtc { get; set; }
        public string? Refrences { get; set; }
    }
}
