using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Infrastructure.Repositories
{
    public class LeddgerRepository  
    {
        private readonly BankDbContext _context;

        public LeddgerRepository(BankDbContext context)

        {
            _context = context;
        }

    }
}
