using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Bank.Application.Features.Ledger.Cammand;
using Bank.Application.Features.Ledger.Dto;
using Bank.Application.Interfaces;
using Bank.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bank.Infrastructure.Repositories
{
    public class LeddgerRepository  : ILedgerRepository
    {
        private readonly BankDbContext _context;

        public LeddgerRepository(BankDbContext context)

        {
            _context = context;
        }

        public async Task<LedgerDto> AddAsync(LedgerDto dto)
        {
            var ledger = new LedgerEntry
            {
                AccountId = dto.AccountId,
                Amount = dto.Amount,
                Direction = dto.Direction,
                CorrelationId = dto.CorrelationId,
                OccuredOnUtc = dto.OccuredOnUtc,
                Narrative = dto.Narrative

            };
            _context.LedgerEntiries.Add(ledger);
            await _context.SaveChangesAsync();
            return dto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entry = await _context.LedgerEntiries.FindAsync(id);
            if (entry == null)
            {
                return false;
            }

            else
            {

                _context.LedgerEntiries.Remove(entry);
                await _context.SaveChangesAsync();
                return true;
            }
            }

        public async Task<IEnumerable<LedgerEntry>> GetAllAsync()
        {
            return await _context.LedgerEntiries.AsNoTracking().Include(l => l.Account).ToListAsync();

        }

        public async Task<IEnumerable<LedgerEntry>> GetByAccountIdAsync(int accountId)
        {
           return await _context.LedgerEntiries.Where(le=>le.AccountId == accountId)
                                   .OrderByDescending(le=>le.OccuredOnUtc).ToListAsync();
        }

        public async Task<LedgerEntry?> GetByIdAsync(int id)
        {
            return await _context.LedgerEntiries
                .Include(le => le.Account)
                .FirstOrDefaultAsync(le => le.Id == id);
        }

    }
}
