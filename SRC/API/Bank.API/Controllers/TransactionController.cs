using System;
using System.Transactions;
using Bank.Application.Features.Transfers.Command;
using Bank.Application.Features.Transfers.Dto;
using Bank.Application.Interfaces;
using Bank.Domain.Entities;
using Bank.Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepository _repo;
        private readonly IMediator _mediator;

        public TransactionController(ITransactionRepository repo, IMediator mediator)
        {
            _repo = repo;
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Alltransfers = await _repo.GetAllAsync();
            return Ok(Alltransfers);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTransferDto dto)
        {
             await _mediator.Send(new CreateTransferCommand(dto));
            return Ok(new { message="Transfer Completed Successfully."});

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var transfer = await _repo.GetByIdAsync(id);
            if (transfer == null)
            {
                return NotFound("Id Not Found ");
            }
            return Ok(transfer);
        }
        //[HttpPut("{id:int}")]
        //public async Task<IActionResult> UpdateTransfer(int id, [FromBody] CreateTransferDto dto)
        //{
        //    if (id != dto.Id)
        //    {
        //        return BadRequest();
        //    }

        //    var update = await _mediator.Send(new CreateTransferCommand(dto));
        //    return Ok(update);
        //}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteTransfer(int id)
        {
            await _repo.DeleteAccAsync(id);
            return Ok();
        }
        

        [HttpGet("GetAccountNoWithTransaction")]
        public async Task<IActionResult> GetAccountNoWithTransaction()
        {
            var transactions = await _repo.GetAccountNoWithTransaction();
            return Ok(transactions);
        }

    }
}
