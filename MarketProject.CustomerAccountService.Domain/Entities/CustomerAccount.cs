using Ardalis.GuardClauses;
using JetBrains.Annotations;
using MarketProject.CustomerAccountService.Domain.ValueObjects;

namespace MarketProject.CustomerAccountService.Domain.Entities
{
    public class CustomerAccount : Entity
    {
        public int CustomerId { get; private set; }
        public Address Address { get; private set; }
        public Email Email { get; private set; }

        private CustomerAccount(int id, int customerId, Address address, Email email)
        {
            Id = Guard.Against.Zero(id, nameof(id), $"{nameof(id)} should not be zero.");
            CustomerId = Guard.Against.Zero(customerId, nameof(customerId), $"{nameof(customerId)} should not be zero.");
            Address = Guard.Against.Null(address, nameof(address), $"{nameof(address)} should not be null.");
            Guard.Against.NullOrEmpty(address.Street, nameof(address.Street), $"{nameof(address.Street)} name not informed.");
            Email = Guard.Against.Null(email, nameof(email), $"{nameof(email)} should not be null.");
        }

        public static CustomerAccount Create(int id, int customerId, Address address, Email email)
        {            
            var customer = new CustomerAccount(id, customerId, address, email);

            return customer;
        }
    }
}