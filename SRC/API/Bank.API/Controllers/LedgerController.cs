using Bank.Application.Features.Ledger.Cammand;
using Bank.Application.Features.Ledger.Dto;
using Bank.Application.Interfaces;
using Bank.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Bank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LedgerController : ControllerBase
    {
        private readonly ILedgerRepository _ledgerRepository;
        private readonly IMediator _mediator;

        public LedgerController(ILedgerRepository ledgerRepository, IMediator mediator)
        {
            _ledgerRepository = ledgerRepository;
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ledgers = await _ledgerRepository.GetAllAsync();
            return Ok(ledgers);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var entry = await _ledgerRepository.GetByIdAsync(id);
            if (entry == null) return NotFound();
            return Ok(entry);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LedgerDto dto)
        {
            var result = await _mediator.Send(new CreateLedgerCommand(dto));
            return Ok(result);
        }



        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _ledgerRepository.DeleteAsync(id);
            if (!result) return NotFound();

            return NoContent();
        }
    }

}
