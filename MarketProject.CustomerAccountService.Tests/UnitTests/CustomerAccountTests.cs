using AutoMapper;
using MarketProject.CustomerAccountService.Application;
using MarketProject.CustomerAccountService.Application.Interfaces;
using MarketProject.CustomerAccountService.Domain.DTOs;
using MarketProject.CustomerAccountService.Domain.Entities;
using MarketProject.CustomerAccountService.Domain.MapperProfiles;
using MarketProject.CustomerAccountService.Domain.RequestModels;
using MarketProject.CustomerAccountService.Domain.ValueObjects;
using MarketProject.CustomerAccountService.Persistence.CQRS.Commands;
using MarketProject.CustomerAccountService.Persistence.CQRS.Commands.Interfaces;
using MarketProject.CustomerAccountService.Persistence.CQRS.Queries;
using MarketProject.CustomerAccountService.Persistence.CQRS.Queries.Interfaces;
using MarketProject.CustomerAccountService.Persistence.Repositories;
using MarketProject.CustomerAccountService.Persistence.Repositories.Interfaces;

namespace MarketProject.CustomerAccountService.Tests.UnitTests
{
    public class CustomerAccountTests
    {
        private readonly ICustomerAccountApplication _customerApplication;
        // private readonly IGetCustomerAccountQuery _getCustomerAccountQuery;
        private readonly IGetCustomersAccountsQuery _getCustomersAccountsQuery;
        private readonly IGetLastCostumerAccountQuery _getLastCostumerAccountQuery;
        private readonly ICreateCustomerAccountCommand _createCustomerAccountCommand;
        private readonly ICustomerAccountRepository _customerAccountRepository;
        private readonly IMapper _mapper;

        public CustomerAccountTests()
        {
            _customerAccountRepository = new CustomerAccountRepository();
            _getCustomersAccountsQuery = new GetCustomersAccountsQuery(_customerAccountRepository);
            _getLastCostumerAccountQuery = new GetLastCostumerAccountQuery(_customerAccountRepository);
            _createCustomerAccountCommand = new CreateCustomerAccountCommand(_customerAccountRepository);
            _mapper = GetAutoMapper();

            _customerApplication = new CustomerAccountApplication(null, null, _getLastCostumerAccountQuery, _createCustomerAccountCommand, _mapper);
        }

        private IMapper GetAutoMapper()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(typeof(CustomerAccountProfile));
                });
                IMapper mapper = mappingConfig.CreateMapper();

                return mapper;
            }

            return _mapper;
        }

        [Fact(DisplayName = "Create a customer account successfuly")]
        public void CreateCustomerAccount()
        {
            // Arrange
            var street = "My street";
            var emailValue = "test@test.com";
            var address = new AddressDTO(street);
            var email = Email.Create(emailValue).Value;
            var request = new CreateCustomerAccountRequestModel(1, address, email.Value);

            // Act
            var qtyOfCustomersBefore = _getCustomersAccountsQuery.Execute().Count();
            var result = _customerApplication.CreateAndReturn(request);
            var qtyOfCustomersAfter = _getCustomersAccountsQuery.Execute().Count();

            // Assert
            result.Should().NotBeNull();
            result.Email.Value.Should().Be(email.Value);
            result.Address.Street.Should().Be(address.Street);
            qtyOfCustomersAfter.Should().Be(qtyOfCustomersBefore + 1);
        }

        [Fact(DisplayName = "Creating customer account empty street throws exception")]
        public void CreatingCustomerAccount_WithStreetEmpty_ShouldThrowAnException()
        {
            // Arrange
            var street = "";
            var emailValue = "test@test.com";
            var address = new AddressDTO(street);
            var email = Email.Create(emailValue).Value;
            var request = new CreateCustomerAccountRequestModel(1, address, email.Value);

            // Act
            Func<CustomerAccountResponseModel> f = () => _customerApplication.CreateAndReturn(request);

            // Assert
            f.Should()
                .Throw<ArgumentException>()
                .WithMessage("Street name not informed*");
        }
    }
}