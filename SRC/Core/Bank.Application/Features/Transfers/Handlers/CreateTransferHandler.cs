using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Bank.Application.Features.Transfers.Command;
using Bank.Application.Features.Transfers.Dto;
using Bank.Application.Interfaces;
using MediatR;

namespace Bank.Application.Features.Transfers.Handlers
{
    public class CreateTransferHandler : IRequestHandler<CreateTransferCommand, CreateTransferDto>
    {
        private readonly ITransactionRepository _repo;
        private readonly IMapper _mapper;

        public CreateTransferHandler(ITransactionRepository  repo, IMapper mapper)
        {
            _repo = repo;
           _mapper = mapper;
        }
        public async Task<CreateTransferDto> Handle(CreateTransferCommand request, CancellationToken cancellationToken)
        {
            var Transaction = await _repo.SendMoneyAsync(request.dto);
            return _mapper.Map<CreateTransferDto>(Transaction);
        }


    }
}
