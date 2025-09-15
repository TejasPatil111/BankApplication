using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Application.Features.Ledger.Dto;
using MediatR;


namespace Bank.Application.Features.Ledger.Cammand
{
    public record CreateLedgerCommand(LedgerDto dto): IRequest<LedgerDto>;  

}
