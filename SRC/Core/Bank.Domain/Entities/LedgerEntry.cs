using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static Bank.Domain.Enums;

namespace Bank.Domain.Entities
{
    public class LedgerEntry
    {
        public int Id { get; set; }
        public Guid AccountId { get; set; }
        public decimal Amount { get; set; }
        public TransactionDirection Direction { get; set; }
        public string? CorrelationId { get; set; }
        public DateTime OccuredOnUtc { get; set; }
        public string? Narrative { get; set; }
    }
}
