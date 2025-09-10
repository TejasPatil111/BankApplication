using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Application.Features.Transfers.Dto;
using MediatR;

namespace Bank.Application.Features.Transfers.Command
{
   
    public record CreateTransferCommand(CreateTransferDto dto): IRequest<CreateTransferDto>;
    
}
