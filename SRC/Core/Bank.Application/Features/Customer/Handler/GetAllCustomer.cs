using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Application.Features.Customer.Dto;
using Bank.Application.Features.Customer.Queries;
using Bank.Application.Interfaces;
using MediatR;

namespace Bank.Application.Features.Customer.Handler
{
    public class GetAllCustomer : IRequestHandler<GetAllCustomerQuery, List<CustomerDto>>
    {
        private readonly ICustomerRepsitory _repo;

        public GetAllCustomer(ICustomerRepsitory repo)
        {
            _repo = repo;
        }

        public async Task<List<CustomerDto>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
        {
            var customers = await _repo.GetAllAsync();
            return customers.Select(c => new CustomerDto
            {
                //Id = c.id,
                Name = c.Name,
                Email = c.Email,
                KeyStatus = c.KeyStatus,
                Status = c.Status,
                CreatedOnUtc = c.CreatedOnUtc
            }).ToList();
        }
    }
}
