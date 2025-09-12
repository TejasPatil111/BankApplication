using Bank.Application.Interfaces;
using Bank.Domain.Entities;
using Bank.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Bank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoneyController : ControllerBase
    {
        private readonly IMoneyRepository _repo;
        public MoneyController(IMoneyRepository repo)
        {
            _repo = repo;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Money = await _repo.GetAllAsync();
            return Ok(Money);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var money = await _repo.GetByIdAsync(id);
            if (money == null) return NotFound();
            return Ok(money);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Money money)
        {
            var result = await _repo.AddAsync(money);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _repo.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Money money)
        {
            var result = await _repo.UpdateAsync(money);
            return Ok(result);
        }

    }
}
