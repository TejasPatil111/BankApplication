using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Application.AuthDto.Auth.Commands;
using Bank.Application.Interfaces;
using MediatR;

namespace Bank.Application.AuthDto.Auth.Handler
{
    public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand, string>
    {
        private readonly ICustomerRepsitory _repo;
        private readonly IEmailSender _emailSender;

        public ForgotPasswordCommandHandler(ICustomerRepsitory repo, IEmailSender emailSender)
        {
            _repo = repo;
            _emailSender = emailSender;
        }
        public async Task<string> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
        {
            var customer = await _repo.GetCustomerByEmailAsync(request.Email);

            if (customer == null)
            {
                return "If Email Exist Reset Link HAs Been Sent.";
            }
            //getreting Token
            var token = Guid.NewGuid().ToString();
            customer.PasswordResetToken = token;
            customer.TokenExpiry = DateTime.UtcNow.AddHours(1);
            await _repo.UpdateAsync(customer);
            
            var resetlink = $"https://yourfrontend.com/reset-password?token={token}";

            //send email
            await _emailSender.SendEmailAsync(customer.Email, "Password Reset",
                $" Dear {customer.Name},\nClick the link to reset your password: {resetlink}");
            return "If the Email Exist , Reset Link Has Been Sent.";
        }
    }
}
