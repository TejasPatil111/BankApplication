using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Domain.Entities;
using MediatR;

namespace Bank.Application.Features.Transfers.Querries
{
    public class QueryGetAccountNoWithTransaction : IRequest<List<Transfer>>
    {

    }
}
