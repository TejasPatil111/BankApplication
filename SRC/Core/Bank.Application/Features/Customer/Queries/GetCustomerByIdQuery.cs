using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Application.Features.Customer.Dto;
using MediatR;

namespace Bank.Application.Features.Customer.Queries
{
    public class GetCustomerByIdQuery :IRequest<CustomerDto>
    {
        public int Id { get; set; }
        public GetCustomerByIdQuery(int id)=> Id = id;

    }
}
