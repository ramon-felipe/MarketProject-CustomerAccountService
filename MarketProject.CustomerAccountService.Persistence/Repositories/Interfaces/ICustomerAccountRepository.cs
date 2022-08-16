using MarketProject.CustomerAccountService.Domain.Entities;
using MarketProject.CustomerAccountService.Domain.RequestModels;

namespace MarketProject.CustomerAccountService.Persistence.Repositories.Interfaces
{
    public interface ICustomerAccountRepository
    {
        CustomerAccount Get(int id);
        IEnumerable<CustomerAccount> Get();
        CustomerAccount Create(CreateCustomerAccountRequestModel request);
    }
}
