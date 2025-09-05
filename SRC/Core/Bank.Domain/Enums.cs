using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Domain
{
    public class Enums
    {
        public enum AccountType { Saving = 1, Current = 2 }
        public enum TransactionType { Deposite = 1, Withdraw = 2, Transfer = 3 }
        public enum AccountStatus { Active = 1, Frozen = 2, Transfer = 3 }
        public enum TransactionDirection { Debit = 1, Credit = 1 }
        public enum CustomerStaus { Active = 1, InActive = 2, Suspended = 3 }
        public enum  TransferStatus { Pending=1,Complete=2,Failed=3 }
    }
}
