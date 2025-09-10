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
            var result = await _mediator.Send(new CreateTransferCommand(dto));
            return Ok(result);

        }

    }
}
