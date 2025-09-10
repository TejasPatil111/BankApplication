using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Domain.Entities;

namespace Bank.Application.Interfaces
{
    public interface ILedgerRepository
    {
        Task<IEnumerable<LedgerEntry>> GetAllAsync();
        Task<LedgerEntry?> GetByIdAsync(int id);
        Task<IEnumerable<LedgerEntry>> GetByAccountIdAsync(int accountId);
        Task<LedgerEntry> AddAsync(LedgerEntry entry);
        Task<bool> DeleteAsync(int id);
    }
}
