using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.Features.Transfers.Dto
{
    public class GetAccountNoWithTransactionDto
    {
        public int id { get; set; }
        public string AccountNo { get; set; }
        public string AccountHolderName { get; set; }
        public string AccountType { get; set; }
        public decimal Balance { get; set; }
        public decimal Amount { get; set; }
        public string FromAC { get; set; }
        public string ToAC { get; set; }
    }
}
