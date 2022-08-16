using MarketProject.CustomerAccountService.Domain.Entities;
using MarketProject.CustomerAccountService.Persistence.CQRS.Queries.Interfaces;
using MarketProject.CustomerAccountService.Persistence.Repositories.Interfaces;

namespace MarketProject.CustomerAccountService.Persistence.CQRS.Queries
{
    public class GetCustomerAccountQuery : IGetCustomerAccountQuery
    {
        private readonly ICustomerAccountRepository _customerAccountRepository;

        public GetCustomerAccountQuery(ICustomerAccountRepository customerAccountRepository)
        {
            _customerAccountRepository = customerAccountRepository;
        }

        public CustomerAccount Execute(int customerAccountId)
        {
            var customer = _customerAccountRepository.Get(customerAccountId);

            return customer;
        }
    }
}
