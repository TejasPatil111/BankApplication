using System.Transactions;
using Bank.Domain.Entities;
using FluentValidation;

namespace Bank.API.Validations
{
    public class TransferValidators :AbstractValidator<Transfer>
    {
        public TransferValidators()
        {
            //RuleFor(t => t.Currency).Must(a => !string.IsNullOrEmpty(a)).WithMessage("Currency Cannot Be Empty");
            //RuleFor(t => t.Refrence).Must(a => !string.IsNullOrEmpty(a)).WithMessage("Refrence Cannot Be Empty");


        }
    }
}
