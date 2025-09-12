using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Application.Interfaces;
using Bank.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bank.Infrastructure.Repositories
{
    public class MoneyRepository : IMoneyRepository
    {
        private readonly BankDbContext _context;

        public MoneyRepository(BankDbContext context)
        {
            _context = context;
        }

        public async Task<Money> AddAsync(Money money)
        {
            _context.Money.Add(money);
            await _context.SaveChangesAsync();
            return money;

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Money.FindAsync(id);
            if (entity == null) 
            {
                return false; 
            }

              _context.Money.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Money>> GetAllAsync()
        {
           return  await _context.Money.ToListAsync();
        }

        public async Task<Money?> GetByIdAsync(int id)
        {
           return await _context.Money.FindAsync(id);
        }

        public async Task<Money> UpdateAsync(Money money)
        {
            _context.Money.Update(money);
            await _context.SaveChangesAsync();
            return money;
        }
    }
}
