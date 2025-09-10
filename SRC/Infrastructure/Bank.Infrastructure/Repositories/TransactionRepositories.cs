using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Application.Features.Transfers.Dto;
using Bank.Application.Interfaces;
using Bank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;

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
            //dto.Id = transfer.Id;
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
            var Alltransfers = await _context.Transfers.Include(a => a.FromAccount).Include(a => a.ToAccount).ToListAsync();
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

        public async Task<CreateTransferDto> UpdateAsync( CreateTransferDto dto)
        {
            var trans = await _context.Transfers.FindAsync(dto.Id);
            if (trans == null)
            {
                throw new KeyNotFoundException("id Not Found:");
            }
            trans.Amount = dto.Amount;
            trans.Currency = dto.Currency;
            trans.Status = dto.Status;
            trans.InitiatedOnUtc = DateTime.UtcNow;
            trans.CompletedOnUtc = DateTime.UtcNow;
            trans.Refrence = dto.Refrence;
            trans.ToAccountId = dto.ToAccountId;
            trans.FromAccountId = dto.FromAccountId;

            await _context.SaveChangesAsync();
            return dto;

        }

    }
}
