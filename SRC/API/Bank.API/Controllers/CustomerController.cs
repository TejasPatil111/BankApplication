using Bank.Application.Features.Customer.Command;
using Bank.Application.Features.Customer.Queries;
using Bank.Application.Interfaces;
using Bank.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepsitory _customerRepository;
        private readonly IMediator _mediator;

        public CustomerController(ICustomerRepsitory customerRepository, IMediator mediator)
        {
            _customerRepository = customerRepository;
            _mediator = mediator;
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
            var customerq = await _mediator.Send(new GetCustomerByIdQuery(id));
            if (customerq == null)
            {
                return NotFound("Id Not Found ");
            }
            var updateCustomer = await _customerRepository.UpdateAsync(customer);
            return Ok(updateCustomer);
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





    }
}
