using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.Features.Account.AccountWithCustomerDto
{

    public class AccountWithCustomerDto
    {
        public int Id { get; set; }
        public string AccountNo { get; set; }

        // Assuming Customer properties
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        // Add other Customer fields as needed
    }

}
