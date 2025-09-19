using System.Reflection.Metadata.Ecma335;
using Bank.Application.Interfaces;
using Bank.Domain.Entities;
using Bank.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Bank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var accounts = await _accountRepository.GetAllAsync();
            return Ok(accounts);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var account = await _accountRepository.GetByIdAsync(id);
            if (account == null)
            {
                return NotFound("Id Not Found ");
            }
            return Ok(account);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Account account)
        {
           
            account.OpendOnUtc = DateTime.UtcNow;

            var created = await _accountRepository.AddAsync(account);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Account account)
        {
            if (id != account.Id)
            {
                throw new KeyNotFoundException("Id Doesnot Found:");
            }


            var updateAcc = await _accountRepository.UpdateAsync(account);
            return Ok(updateAcc);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           var deleted = await _accountRepository.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound();
                    
            }

            return NoContent();
        }

        // New API endpoint to get accounts joined with customers using SP
        [HttpGet("with-customers")]
        public async Task<IActionResult> GetAccountsWithCustomers()
        {
            try
            {
                var accountsWithCustomers = await _accountRepository.GetAccountsWithCustomersAsync();
                return Ok(accountsWithCustomers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }

    }





