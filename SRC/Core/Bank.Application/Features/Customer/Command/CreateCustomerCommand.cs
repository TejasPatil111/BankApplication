using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Application.Features.Customer.Dto;
using MediatR;
using static Bank.Domain.Enums;

namespace Bank.Application.Features.Customer.Command
{
    public record CreateCustomerCommand(CustomerDto dto) : IRequest<int>
    {
        public string Name { get; internal set; }
        public string Email { get; internal set; }
        public bool KeyStatus { get; internal set; }
        public CustomerStaus Status { get; internal set; }
    }
}
