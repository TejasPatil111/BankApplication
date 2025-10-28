using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Application.Features.Account.AccountWithCustomerDto;
using Bank.Application.Features.Account.Dtos;
using Bank.Domain.Entities;

namespace Bank.Application.Interfaces
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAllAsync();
        Task<Account?> GetByIdAsync(int id);
        Task<Account> AddAsync(Account account);
        Task<Account> UpdateAsync(Account account);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<AccountWithCustomerDto>> GetAccountsWithCustomersAsync(int? cutomerId = null);
        Task<CheckBalanceDto> CheckBalance(int CustomerId, string PinCode);
    }
}
