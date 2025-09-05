using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using Bank.Application.Interfaces;
using Bank.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bank.Infrastructure.Repositories
{
    public class CustomerRepositories : ICustomerRepsitory
    {
        private readonly BankDbContext _context;
        public CustomerRepositories(BankDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Customer customer)

        {
            try
            {
                if (customer == null)
                {

                    throw new ArgumentNullException(nameof(customer), "Customer object cannot be empty");
                }
                await _context.Customers.AddAsync(customer);
                await _context.SaveChangesAsync();


            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error while adding customer", ex);
            }   



        }

        public async Task Delete(Guid id)
        {
            var CustomId = await _context.Customers.FindAsync(id);
            
            
                if (CustomId != null)
            {
                _context.Customers.Remove(CustomId);
                await _context.SaveChangesAsync(); // Saving Changes
            }
        }
            


        

        public async Task<IEnumerable<Customer>> GetCustomersAsync(Guid? id = null, string? name = null)
        {
            try
            {
                IQueryable<Customer> query = _context.Customers;

                if (id.HasValue)
                {
                    var customer = await _context.Customers.FindAsync(id.Value);
                    return customer != null ? new List<Customer> { customer } : Enumerable.Empty<Customer>();
                }

                if (!string.IsNullOrWhiteSpace(name))
                {
                    query = query.Where(c => c.Name.Contains(name));
                }

                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error while fetching customers", ex);
            }
        }

        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException(nameof(customer), "Customer object cannot be empty");

            var existing = await _context.Customers.FindAsync(customer.id);

            if (existing == null)
                throw new KeyNotFoundException($"Customer with Id '{customer.id}' not found.");

            _context.Entry(existing).CurrentValues.SetValues(customer);
            await _context.SaveChangesAsync();

            return existing;
        }

    }
}
