using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Application.Features.Customer.Command;
using Bank.Application.Features.Customer.Dto;
using Bank.Application.Interfaces;
using MediatR;
using Bank.Domain.Entities;


namespace Bank.Application.Features.Customer.Handler
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, int>
    {
        private readonly ICustomerRepsitory _repo;

        public CreateCustomerHandler(ICustomerRepsitory repo)
        {
            _repo = repo;

        }

        public async  Task<int> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new Bank.Domain.Entities.Customer
            {
                Name = request.Name,
                Email = request.Email,
                KeyStatus = request.KeyStatus,
                Status = request.Status,
                CreatedOnUtc = DateTime.UtcNow
            };
            await _repo.AddAsync(customer);
          return customer.id;


        }
    }
}
