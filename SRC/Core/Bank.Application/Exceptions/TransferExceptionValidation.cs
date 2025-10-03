using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.Exceptions
{
    public class TransferExceptionValidation : ApplicationException
    {
        public TransferExceptionValidation(string message):base (message)
        {
            
        }
    }
}
