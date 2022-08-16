using AutoMapper;
using MarketProject.CustomerAccountService.Domain.Entities;
using MarketProject.CustomerAccountService.Domain.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketProject.CustomerAccountService.Domain.MapperProfiles
{
    public class CustomerAccountProfile : Profile
    {
        public CustomerAccountProfile()
        {
            CreateMap<CustomerAccount, CustomerAccountResponseModel>();
        }
    }
}
