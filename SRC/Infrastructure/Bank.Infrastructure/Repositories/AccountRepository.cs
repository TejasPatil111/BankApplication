using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Application.Exceptions;
using Bank.Application.Interfaces;
using Bank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Bank.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BankDbContext _context;

        public AccountRepository(BankDbContext context)
        {
            _context = context;
        }

        public async Task<Account> AddAsync(Account account)
        {
            try
            {
                if (account == null)
                {
                    throw new ArgumentNullException("Customer Details Not Added", nameof(account));
                }
                await _context.Accounts.AddAsync(account);
                await _context.SaveChangesAsync();

                return account;


            }
            catch (ArgumentNullException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error while adding account", ex);
            }
        }

        public async Task<bool> DeleteAsync(int id)

        {
            var accountrow = await _context.Accounts.FindAsync(id);
            if (accountrow == null) return false;

            _context.Accounts.Remove(accountrow);
            await _context.SaveChangesAsync();
            return true;
        }




        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            try
            {
                var accounts = await _context.Accounts.ToListAsync();
                if (accounts == null)
                {
                    throw new KeyNotFoundException("No Account Found");
                }
                return accounts;

            }

            catch (KeyNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error while fetching accounts", ex);
            }
        }

        public async Task<Account?> GetByIdAsync(int id)
        {
            try

            {
                var AccountId = await _context.Accounts.FirstOrDefaultAsync(a => a.Id == id);

                if (AccountId == null)
                {
                    throw new AccountNotFoundException(id);
                }
                return AccountId;

            }
            catch (KeyNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error while fetching account by Id", ex);
            }

        }

        public async Task<Account> UpdateAsync(Account account)
        {
            if (account == null) { 
            throw new ArgumentNullException(nameof(account), "Account object cannot be null");
            }
            var existing = await _context.Accounts.FindAsync(account.Id);
            if (existing == null)
            {
                throw new KeyNotFoundException($"Account with Id '{account.Id}' not found.");
            }
            _context.Entry(existing).CurrentValues.SetValues(account);
            await _context.SaveChangesAsync();
            return existing;


        }




    }
}
