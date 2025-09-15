using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.Exceptions
{
    public class BankApplicationException : Exception
    {
        public BankApplicationException(string  message): base(message)
        {
            
        }
    }
}
