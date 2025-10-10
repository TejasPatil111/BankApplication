using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Bank.Application.AuthDto.Auth.Commands
{
    public class ResetPaswordCommand : IRequest<string>
    {
        public string Token { get; set; }
        public string NewPassword { get; set; }
    }
    
}
