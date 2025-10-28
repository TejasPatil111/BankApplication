using Bank.Domain.Entities;
using FluentValidation;

namespace Bank.API.Validations
{
    public class AccountValidators : AbstractValidator<Account>
    {
        public AccountValidators()
        {
            //RuleFor(a => a.AccountNo).Must(a => !string.IsNullOrEmpty(a)).WithMessage("Account No Cannot Be Empty");
            //RuleFor(a => a.Currency).Must(a => !string.IsNullOrEmpty(a)).WithMessage("Currency Cannot Be Empty");
            //RuleFor(a => a.pincode).Must(a => !string.IsNullOrEmpty(a)).WithMessage("PinCode  Cannot Be Empty");

        }
    }
}
