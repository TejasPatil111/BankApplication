using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Application.Features.Customer.Dto;
using Bank.Domain.Entities;

namespace Bank.Application.Interfaces
{
    public interface ICustomerRepsitory
    {
        Task<Customer> GetByIdAsync(int id);
        Task<List<Customer>> GetAllAsync();
        Task<Customer> UpdateAsync(int id, Customer customer);
        Task DeleteAsync(int id);
        Task AddAsync(Customer customer);

        Task<Customer> GetCustomerByEmailAsync(string email);
        Task<Customer> GetCustomerByTokenAsync(string token);
        Task UpdateAsync(Customer customer);

    }
}
