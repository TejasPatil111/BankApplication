using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.Features.Transfers.Dto
{
    public class CreateTransferDto
    {

        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; } = "INR";
        public int Status { get; set; }
        public DateTime InitiatedOnUtc { get; set; }
        public DateTime? CompletedOnUtc { get; set; }
        public string? Refrence { get; set; }

        public int ToAccountId { get; set; }
        public int FromAccountId { get; set; }
    }
}
