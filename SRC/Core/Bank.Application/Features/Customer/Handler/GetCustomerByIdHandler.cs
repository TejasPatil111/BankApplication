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
        private readonly IAccountRepository _accountRepository;

        public GetCustomerByIdHandler(ICustomerRepsitory repo, IAccountRepository accountRepository)
        {
            _repo = repo;
            _accountRepository = accountRepository;
        }

        public async Task<CustomerDto> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _repo.GetByIdAsync(request.Id);
            //var accountNumber = await _context.Accounts.Where(c => c.CustomerId == id).FirstOrDefaultAsync();
            var accountdetails = (await _accountRepository.GetAccountsWithCustomersAsync(request.Id)).FirstOrDefault();
            if (data == null)
            {
                throw new KeyNotFoundException("Id Not Found");
            }
            return new CustomerDto
            {
                Id = data.id,
                AccountNo = accountdetails.AccountNo,
                Name = data.Name,
                Email = data.Email,
                Password=data.Password,
                Role=data.Role,
                KeyStatus = data.KeyStatus,
                Status = data.Status,
                CreatedOnUtc = data.CreatedOnUtc
            };
            



        }
    }
}
