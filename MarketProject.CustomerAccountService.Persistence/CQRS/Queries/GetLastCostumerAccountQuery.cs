using MarketProject.CustomerAccountService.Domain.Entities;
using MarketProject.CustomerAccountService.Persistence.CQRS.Queries.Interfaces;
using MarketProject.CustomerAccountService.Persistence.Repositories.Interfaces;

namespace MarketProject.CustomerAccountService.Persistence.CQRS.Queries
{
    public class GetLastCostumerAccountQuery : IGetLastCostumerAccountQuery
    {
        private readonly ICustomerAccountRepository _customerAccountRepository;

        public GetLastCostumerAccountQuery(ICustomerAccountRepository customerAccountRepository)
        {
            _customerAccountRepository = customerAccountRepository;
        }

        public CustomerAccount Execute()
        {
            return _customerAccountRepository.Get().Last();
        }
    }
}
