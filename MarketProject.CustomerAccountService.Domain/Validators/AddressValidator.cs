using FluentValidation;
using MarketProject.CustomerAccountService.Domain.DTOs;
using MarketProject.CustomerAccountService.Domain.Entities;
using MarketProject.CustomerAccountService.Domain.Validators.CustomValidators;
using MarketProject.CustomerAccountService.Domain.ValueObjects;

namespace MarketProject.CustomerAccountService.Domain.Validators
{
    public class AddressValidator : AbstractValidator<AddressDTO>
    {
        public AddressValidator()
        {
            RuleFor(address => address.Street)
                .MustBeValueObject(address => Address.Create(address)) // It executes the validations present on Create method of the Address domain class
                /*.NotNull()
                .WithMessage(address => $"{nameof(address.Street)} is null")
                .Length(10, 100)
                .StreetNameShouldStartWith("rua")*/
                .When(address => address != null);
        }
    }
}
