using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Application.Features.Transfers.Dto;
using MediatR;

namespace Bank.Application.Features.Transfers.Command
{
    public class ReverseTransactionCommand : IRequest<ReverseTransactionDto>
    {
        public int transactionId { get; set; }
        public string Reference { get;  set; }
    }



}
