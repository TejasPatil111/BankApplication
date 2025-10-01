using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Domain.Entities;
using FluentValidation;

namespace Bank.API.Validations
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.Name)
                .Must(c => !string.IsNullOrEmpty(c))
                .WithMessage("Name cannot be empty");

            RuleFor(c => c.Email)
                .Must(c => !string.IsNullOrEmpty(c))
                .WithMessage("Email cannot be empty!!!");

            RuleFor(c => c.Password)
                .Must(c => !string.IsNullOrEmpty(c))
                .WithMessage("Password cannot be empty");
        }
    }
}
