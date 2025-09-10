using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Bank.Application.Features.Transfers.Dto;
using Bank.Domain.Entities;

namespace Bank.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateTransferDto, Transfer>().ReverseMap();
        }
    }
}
