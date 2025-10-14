using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Application.AuthDto.Auth.Commands;
using Bank.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Bank.Application.AuthDto.Auth.Handler
{
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPaswordCommand, string>
    {
        private readonly ICustomerRepsitory _repo;
        private readonly IPasswordHasher<object> _passwordHasher;
        public ResetPasswordCommandHandler(ICustomerRepsitory repo)
        {
            _repo = repo;
            _passwordHasher = new PasswordHasher<object>();
        }


        public async Task<string> Handle(ResetPaswordCommand request, CancellationToken cancellationToken)
        {
            var customer =await _repo.GetCustomerByTokenAsync(request.Token);
            if (customer == null || customer.OtpExpiry < DateTime.UtcNow)
            {
                throw new Exception("Invalid or Expired Token");
            }
            // hash newpass
            customer.Password = _passwordHasher.HashPassword(null, request.NewPassword);
            //claer token
            customer.OtpCode = null;
            customer.OtpExpiry = null;
            await _repo.UpdateAsync(customer);

            return "Password reset successful.";
        }
    }
}
