using MarketProject.CustomerAccountService.Domain.Entities;
using MarketProject.CustomerAccountService.Persistence.CQRS.Queries.Interfaces;
using MarketProject.CustomerAccountService.Persistence.Repositories.Interfaces;

namespace MarketProject.CustomerAccountService.Persistence.CQRS.Queries
{
    public class GetCustomersAccountsQuery : IGetCustomersAccountsQuery
    {
        private readonly ICustomerAccountRepository _customerAccountRepository;

        public GetCustomersAccountsQuery(ICustomerAccountRepository customerAccountRepository)
        {
            _customerAccountRepository = customerAccountRepository;
        }

        public IEnumerable<CustomerAccount> Execute()
        {
            return _customerAccountRepository.Get();
        }
    }
}
