using Bank.Application.Features.Customer.Command;
using Bank.Application.Features.Customer.Queries;
using Bank.Application.Features.Transfers.Command;
using Bank.Application.Interfaces;
using Bank.Domain.Entities;
using Bank.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepsitory _customerRepository;
        private readonly IMediator _mediator;
        private readonly BankDbContext _context;

        public CustomerController(ICustomerRepsitory customerRepository, IMediator mediator,BankDbContext context)
        {
            _customerRepository = customerRepository;
            _mediator = mediator;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomer([FromQuery] int? id, [FromQuery] string? name)
        {
            var customers = await _mediator.Send(new GetAllCustomerQuery());
            return Ok(customers);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _mediator.Send(new GetCustomerByIdQuery(id));
            if (customer == null)
            {
                return NotFound("Id Not Found ");
            }
            return Ok(customer);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateCustomer([FromBody] Customer customer, int id)
        {
            var updatedCustomer = await _customerRepository.UpdateAsync(id, customer);
            if (updatedCustomer == null)
            {
                return NotFound("Id Not Found");
            }

            return Ok(updatedCustomer);
        }


        [HttpPost]
        public async Task<IActionResult> AddCustomer(CreateCustomerCommand Command)
        {
            var id = await _mediator.Send(Command);
            return Ok(new { CustomerId = id });
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            await _customerRepository.DeleteAsync(id);
            return NoContent();
        }


        [HttpGet("CheckCustomerAccount/{customerId}")]
        public async Task<IActionResult> CheckCustomerAccount(int customerId)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(a => a.CustomerId == customerId);

            if (account == null)
                return Ok(new { hasAccount = false });

            return Ok(new { hasAccount = true });
        }






    }
}
