using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Application.Features.Transfers.Command;
using Bank.Application.Features.Transfers.Dto;
using Bank.Application.Interfaces;
using Bank.Domain.Entities;
using MediatR;
using static Bank.Domain.Enums;

namespace Bank.Application.Features.Transfers.Handlers
{
    public class TransferCommandHandler : IRequestHandler<CreateTransferCommand, CreateTransferDto>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IAccountRepository _accountRepository;

        public TransferCommandHandler(ITransactionRepository transactionRepository, IAccountRepository accountRepository)
        {
            _transactionRepository = transactionRepository;
            _accountRepository = accountRepository;
        }

        public async Task<CreateTransferDto> Handle(CreateTransferCommand request, CancellationToken cancellationToken)
        {
            var FromAcc = await _accountRepository.GetByIdAsync(request.dto.FromAccountId);
            var ToAcc = await _accountRepository.GetByIdAsync(request.dto.ToAccountId);
            if (FromAcc.Balance < request.dto.Amount)
            {
                throw new InvalidOperationException("Insufficient Balance:");
            }
            FromAcc.Balance = FromAcc.Balance - request.dto.Amount;
            ToAcc.Balance = ToAcc.Balance + request.dto.Amount;

            var transfer = new Transfer
            {
                FromAccountId = request.dto.FromAccountId,
                ToAccountId = request.dto.ToAccountId,
                Amount = request.dto.Amount,
                Currency = "INR",
                Status = (int)TransferStatus.Complete,
                InitiatedOnUtc = DateTime.UtcNow,
                CompletedOnUtc = DateTime.UtcNow,

            };
            await _transactionRepository.AddAccAsync(transfer);

            return new CreateTransferDto
            {
                Id = transfer.Id,
                FromAccountId = transfer.FromAccountId,
                ToAccountId = transfer.ToAccountId,
                Amount = transfer.Amount,
                Status = transfer.Status,
                
            };


        }
    }
}
