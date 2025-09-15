using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.Exceptions
{
    public class AccountNotFoundException : BankApplicationException
    {
        public AccountNotFoundException( int id ): base($"Account with AccountId {id} Not Found.")
        {
            
        }
    }
}
