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
    public class CreateTransferHandler : IRequestHandler<CreateTransferCommand, CreateTransferDto>
    {
        private readonly ITransactionRepository _repo;

        public CreateTransferHandler(ITransactionRepository  repo)
        {
            _repo = repo;
        }
        public async Task<CreateTransferDto> Handle(CreateTransferCommand request, CancellationToken cancellationToken)
        {
            return await _repo.AddAccAsync(request.dto);
        }

        
    }
}
