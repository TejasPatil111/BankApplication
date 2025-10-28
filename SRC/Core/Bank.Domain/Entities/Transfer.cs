using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Bank.Domain.Enums;

namespace Bank.Domain.Entities
{
    public class Transfer
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; } = "INR";
        public int Status { get; set; }
        public DateTime InitiatedOnUtc { get; set; }
        public DateTime? CompletedOnUtc { get; set; }
        public string? Refrence { get; set; }
        public int? ParentTransactionId { get; set; }
        public string TransactionType { get; set; } = "Normal";
        public decimal FromBalanceAfter { get; set; }
        public decimal ToBalanceAfter { get; set; }

        //optional self-refrencing relationship
        public Transfer? ParentTransaction { get; set; }

        //navigation Proerties
        public int FromAccountId { get; set; }
        public int ToAccountId { get; set; }
        public Account? FromAccount { get; set; }
        public Account? ToAccount { get; set; }
    }
}
