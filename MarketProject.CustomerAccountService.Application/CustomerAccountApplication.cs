using AutoMapper;
using MarketProject.CustomerAccountService.Application.Interfaces;
using MarketProject.CustomerAccountService.Domain.RequestModels;
using MarketProject.CustomerAccountService.Persistence.CQRS.Commands.Interfaces;
using MarketProject.CustomerAccountService.Persistence.CQRS.Queries.Interfaces;

namespace MarketProject.CustomerAccountService.Application
{
    public class CustomerAccountApplication : ICustomerAccountApplication
    {
        private readonly IGetCustomerAccountQuery _getCustomerAccountQuery;
        private readonly IGetCustomersAccountsQuery _getCustomersAccountsQuery;
        private readonly IGetLastCostumerAccountQuery _getLastCostumerAccountQuery;
        private readonly ICreateCustomerAccountCommand _createCustomerAccountCommand;
        private readonly IMapper _mapper;

        public CustomerAccountApplication(IGetCustomerAccountQuery getCustomerAccountQuery,
                                          IGetCustomersAccountsQuery getCustomersAccountsQuery,
                                          IGetLastCostumerAccountQuery getLastCostumerAccountQuery,
                                          ICreateCustomerAccountCommand createCustomerAccountCommand,
                                          IMapper mapper)
        {
            _getCustomerAccountQuery = getCustomerAccountQuery;
            _getCustomersAccountsQuery = getCustomersAccountsQuery;
            _getLastCostumerAccountQuery = getLastCostumerAccountQuery;
            _createCustomerAccountCommand = createCustomerAccountCommand;
            _mapper = mapper;
        }


        public CustomerAccountResponseModel Get(int id)
        {
            var customer = _getCustomerAccountQuery.Execute(id);
            var result = _mapper.Map<CustomerAccountResponseModel>(customer);
            
            return result;
        }

        public IEnumerable<CustomerAccountResponseModel> Get()
        {
            var customers = _getCustomersAccountsQuery.Execute();

            var result = _mapper.Map<IEnumerable<CustomerAccountResponseModel>>(customers);
            
            return result;
        }
        public CustomerAccountResponseModel CreateAndReturn(CreateCustomerAccountRequestModel request)
        {            
            _createCustomerAccountCommand.Execute(request);
            var newAccount = _getLastCostumerAccountQuery.Execute();
            var result = _mapper.Map<CustomerAccountResponseModel>(newAccount);

            return result;
        }
    }
}