using AutoMapper;
using MarketProject.CustomerAccountService.Application.Interfaces;
using MarketProject.CustomerAccountService.Domain.RequestModels;
using MarketProject.CustomerAccountService.Persistence.CQRS.Commands.Interfaces;
using MarketProject.CustomerAccountService.Persistence.CQRS.Queries.Interfaces;
using MarketProject.CustomerAccountService.Services.MessageService.Interfaces;

namespace MarketProject.CustomerAccountService.Application
{
    public class CustomerAccountApplication : ICustomerAccountApplication
    {
        private readonly IGetCustomerAccountQuery _getCustomerAccountQuery;
        private readonly IGetCustomersAccountsQuery _getCustomersAccountsQuery;
        private readonly IGetLastCostumerAccountQuery _getLastCostumerAccountQuery;
        private readonly ICreateCustomerAccountCommand _createCustomerAccountCommand;
        private readonly IMapper _mapper;
        private readonly IMessageService _messageService;

        public CustomerAccountApplication(IGetCustomerAccountQuery getCustomerAccountQuery,
                                          IGetCustomersAccountsQuery getCustomersAccountsQuery,
                                          IGetLastCostumerAccountQuery getLastCostumerAccountQuery,
                                          ICreateCustomerAccountCommand createCustomerAccountCommand,
                                          IMapper mapper,
                                          IMessageService messageService)
        {
            _getCustomerAccountQuery = getCustomerAccountQuery;
            _getCustomersAccountsQuery = getCustomersAccountsQuery;
            _getLastCostumerAccountQuery = getLastCostumerAccountQuery;
            _createCustomerAccountCommand = createCustomerAccountCommand;
            _mapper = mapper;
            _messageService = messageService;
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

            _messageService.Consume("testQueue");


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