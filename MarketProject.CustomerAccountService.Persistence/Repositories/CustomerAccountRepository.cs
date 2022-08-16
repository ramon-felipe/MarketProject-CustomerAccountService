using MarketProject.CustomerAccountService.Domain;
using MarketProject.CustomerAccountService.Domain.Entities;
using MarketProject.CustomerAccountService.Domain.RequestModels;
using MarketProject.CustomerAccountService.Domain.ValueObjects;
using MarketProject.CustomerAccountService.Persistence.Repositories.Interfaces;
using System.Linq;

namespace MarketProject.CustomerAccountService.Persistence.Repositories
{
    public class CustomerAccountRepository : ICustomerAccountRepository
    {
        private IList<CustomerAccount> customersAccounts = new List<CustomerAccount>();

        public CustomerAccountRepository()
        {
            Init();
        }

        public IEnumerable<CustomerAccount> Get()
            => customersAccounts;


        public CustomerAccount Get(int id)
        {
            var customerAccount = customersAccounts.First(c => c.Id == id);

            return customerAccount;
        }

        public CustomerAccount Create(CreateCustomerAccountRequestModel request)
        {
            var lastId = customersAccounts.OrderByDescending(c => c.Id).First().Id;
            var newId = lastId + 1;
            var email = Email.Create(request.Email).Value;
            var address = Address.Create(request.Address.Street).Value;
            var newCustomerAccount = CustomerAccount.Create(newId, request.CustomerId, address, email);

            customersAccounts.Add(newCustomerAccount);

            return newCustomerAccount;
        }

        private void Init()
        {
            var email1 = Email.Create("x@hotmail.com");
            var email2 = Email.Create("y@hotmail.com");
            var email3 = Email.Create("z@hotmail.com");
            var email4 = Email.Create("z2@hotmail.com");

            var customerAccount1 = CustomerAccount.Create(1, 1, Address.Create("Rua xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx").Value, email1.Value);
            var customerAccount2 = CustomerAccount.Create(2, 2, Address.Create("Rua yyyyyyyyyyyyyyyyyyyyyyyyyyyyyy").Value, email2.Value);
            var customerAccount3 = CustomerAccount.Create(3, 3, Address.Create("Rua zzzzzzzzzzzzzzzzzzzzzzzzzzzzzz").Value, email3.Value);
            var customerAccount4 = CustomerAccount.Create(4, 3, Address.Create("Rua zzzzzzzzzzzzzzzzzzzzzzzzzzzzz2").Value, email4.Value);

            customersAccounts = new List<CustomerAccount> { customerAccount1, customerAccount2, customerAccount3, customerAccount4 };
        }


    }
}