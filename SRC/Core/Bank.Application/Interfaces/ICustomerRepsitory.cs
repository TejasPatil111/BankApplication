using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Domain.Entities;

namespace Bank.Application.Interfaces
{
    public interface ICustomerRepsitory
    {
        Task<IEnumerable<Customer>> GetCustomersAsync(Guid? id = null, string? name = null);
        Task<Customer> UpdateCustomer(Customer customer);
        Task AddAsync(Customer customer);
        Task Delete(Guid id);

    }
}
