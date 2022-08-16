using MarketProject.CustomerAccountService.Domain;
using MarketProject.CustomerAccountService.Domain.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketProject.CustomerAccountService.Application.Interfaces
{
    public interface ICustomerAccountApplication
    {
        CustomerAccountResponseModel Get(int id);
        IEnumerable<CustomerAccountResponseModel> Get();
        CustomerAccountResponseModel CreateAndReturn(CreateCustomerAccountRequestModel request);
    }
}
