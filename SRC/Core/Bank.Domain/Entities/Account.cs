using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Bank.Domain.Enums;

namespace Bank.Domain.Entities
{
    public class Account
    {

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string? AccountNo { get; set; }
        public AccountType AccountType { get; set; }

        public AccountStatus Status { get; set; }
        public decimal Balance { get; set; }
        public string Currency { get; set; } = "INR";
        public DateTime OpendOnUtc { get; set; }
        public DateTime? ClosedOnUtc { get; set; }
        public byte[] RowVersion { get; set; } = Array.Empty<byte>();

        

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new InvalidOperationException("Deposit amount must be positive.");

            }
            Balance += amount;
        }
        public void withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new InvalidOperationException("Withdraw amount must be positive.");
            }
            if (amount > Balance)
            {
                throw new InvalidOperationException("Insufficient funds for this withdrawal.");
            }
            Balance -= amount;
        }


    }
}
