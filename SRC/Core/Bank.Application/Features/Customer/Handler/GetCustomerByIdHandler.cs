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
    public class GetCustomerByIdHandler: IRequestHandler<GetCustomerByIdQuery, CustomerDto>
    {
        private readonly ICustomerRepsitory _repo;

        public GetCustomerByIdHandler(ICustomerRepsitory repo)
        {
            _repo = repo;
        }

        public async Task<CustomerDto> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _repo.GetByIdAsync(request.Id);
            if (data == null)
            {
                throw new KeyNotFoundException("Id Not Found");
            }
            return new CustomerDto
            {
                //Id = data.id,
                Name = data.Name,
                Email = data.Email,
                KeyStatus = data.KeyStatus,
                Status = data.Status,
                CreatedOnUtc = data.CreatedOnUtc
            };
            



        }
    }
}
