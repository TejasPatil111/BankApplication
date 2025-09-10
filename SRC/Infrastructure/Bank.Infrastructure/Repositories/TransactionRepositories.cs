using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Application.Features.Transfers.Dto;
using Bank.Application.Interfaces;
using Bank.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bank.Infrastructure.Repositories
{
    public class TransactionRepositories : ITransactionRepository
    {
        private readonly BankDbContext _context;

        public TransactionRepositories(BankDbContext Context)
        {
            _context = Context;
        }

        public async Task<CreateTransferDto> AddAccAsync(CreateTransferDto dto)
        {
            var transfer = new Transfer
            {
                Amount = dto.Amount,
                Currency = dto.Currency,
                Status = dto.Status,
                InitiatedOnUtc = DateTime.UtcNow,
                CompletedOnUtc = DateTime.UtcNow,
                Refrence = dto.Refrence,
                ToAccountId = dto.ToAccountId,
                FromAccountId = dto.FromAccountId
            };
            _context.Transfers.Add(transfer);
            await _context.SaveChangesAsync();
            dto.Id = transfer.Id;
            return dto;
        }







        

        public async Task<bool> DeleteAccAsync(int id)
        {
            var Transaction = await _context.Transfers.FindAsync(id);
            if (Transaction == null)
            {
                throw new KeyNotFoundException($"Transfer Id {Transaction}");
            }

            _context.Transfers.Remove(Transaction);

            await _context.SaveChangesAsync();
            return true;

        }


        public async Task<IEnumerable<Transfer>> GetAllAsync()
        {
            var Alltransfers = await _context.Transfers.ToListAsync();
            return Alltransfers;

        }

        public async Task<Transfer> GetByIdAsync(int id)
        {
            var transactionId = await _context.Transfers.FirstOrDefaultAsync(t => t.Id == id);
            if (transactionId == null)
            {
                throw new KeyNotFoundException($"trancation Id :{transactionId} Not Found");
            }

            return transactionId;
        }

        public Task<Transfer> UpdateAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
