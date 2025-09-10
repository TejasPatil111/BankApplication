using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Application.Features.Transfers.Dto;
using Bank.Domain.Entities;

namespace Bank.Application.Interfaces
{
    public interface ITransactionRepository
    {
        Task<Transfer> GetByIdAsync(int id);
        Task<IEnumerable<Transfer>> GetAllAsync();
        
        Task<bool> DeleteAccAsync(int id);
        Task<Transfer> UpdateAsync(int id);
        Task<CreateTransferDto> AddAccAsync(CreateTransferDto dto);
    }
}
