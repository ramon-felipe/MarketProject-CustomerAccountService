using MarketProject.CustomerAccountService.Domain.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketProject.CustomerAccountService.Persistence.CQRS.Commands.Interfaces
{
    public interface ICreateCustomerAccountCommand
    {
        void Execute(CreateCustomerAccountRequestModel request);
    }
}
