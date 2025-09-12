using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Application.Features.Ledger.Cammand;
using Bank.Application.Features.Ledger.Dto;
using Bank.Application.Interfaces;
using MediatR;

namespace Bank.Application.Features.Ledger.Handler
{
    public class CreateLedgerEntriesHandler : IRequestHandler<CreateLedgerCommand, LedgerDto>
    {
        private readonly ILedgerRepository _repo;

        public CreateLedgerEntriesHandler(ILedgerRepository repo)
        {
            
            _repo = repo;
        }

        public async  Task<LedgerDto> Handle(CreateLedgerCommand request, CancellationToken cancellationToken)
        {

            return await _repo.AddAsync(request.dto);
        }
    }
}
