using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Bank.Domain.Enums;

namespace Bank.Application.Features.Ledger.Dto
{
    public class LedgerDto
    {
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public TransactionDirection Direction { get; set; }
        public string? CorrelationId { get; set; }
        public DateTime OccuredOnUtc { get; set; }
        public string? Narrative { get; set; }
    }
}
