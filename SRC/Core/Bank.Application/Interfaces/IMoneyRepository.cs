using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Domain.Entities;

namespace Bank.Application.Interfaces
{
    public interface IMoneyRepository
    {
        Task<IEnumerable<Money>> GetAllAsync();
        Task<Money?> GetByIdAsync(int id);
        Task<Money> AddAsync(Money money);
        Task<Money> UpdateAsync(Money money);
        Task<bool> DeleteAsync(int id);
    }
}
