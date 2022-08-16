using MarketProject.CustomerAccountService.Domain.RequestModels;
using MarketProject.CustomerAccountService.Persistence.CQRS.Commands.Interfaces;
using MarketProject.CustomerAccountService.Persistence.Repositories.Interfaces;

namespace MarketProject.CustomerAccountService.Persistence.CQRS.Commands
{
    public class CreateCustomerAccountCommand : ICreateCustomerAccountCommand
    {
        private readonly ICustomerAccountRepository _customerAccountRepository;

        public CreateCustomerAccountCommand(ICustomerAccountRepository customerAccountRepository)
        {
            _customerAccountRepository = customerAccountRepository;
        }

        public void Execute(CreateCustomerAccountRequestModel request)
        {
            _customerAccountRepository.Create(request);
        }
    }
}
