using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.Exceptions
{
    public class CustomerNotFoundException : BankApplicationException    
    {
        public CustomerNotFoundException( int id ): base($"Customer with Id {id} NotFound.")
        {
             
        }
    }
}
