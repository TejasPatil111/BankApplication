using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Application.Features.Transfers.Command;
using Bank.Application.Features.Transfers.Dto;
using Bank.Application.Interfaces;
using MediatR;

namespace Bank.Application.Features.Transfers.Handlers
{
    public class RevrseTransactionHandler : IRequestHandler<ReverseTransactionCommand, ReverseTransactionDto>
    {
        private readonly ITransactionRepository _repo;

        public RevrseTransactionHandler(ITransactionRepository repo)
        {
            _repo = repo;
        }
        public async Task<ReverseTransactionDto> Handle(ReverseTransactionCommand request, CancellationToken cancellationToken)
        {
            return await _repo.ReverseTransactionAsync(request.transactionId, request.Reference);
        }
    }
}
