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
        public CustomerController(ICustomerRepsitory customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomer([FromQuery] Guid? id, [FromQuery] string? name)
        {
            try
            {
                var customers = await _customerRepository.GetCustomersAsync(id, name);

                if (customers == null || !customers.Any())
                {
                    return NotFound(new { message = "No customers found matching the criteria." });
                }

                return Ok(customers);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { message = "An error occurred while retrieving customers.", details = ex.Message });
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCustomer([FromBody] Customer customer)
        {
            var updateCustomer = await _customerRepository.UpdateCustomer(customer);
            return Ok(updateCustomer);
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromBody] Customer customer)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _customerRepository.AddAsync(customer);
            return CreatedAtAction(nameof(GetCustomer), new { id = customer.id }, customer);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            await _customerRepository.Delete(id);
            return NoContent();
        }


        

    }
}
