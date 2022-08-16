using FluentValidation;
using MarketProject.CustomerAccountService.Domain.Validators.CustomValidators;
using MarketProject.CustomerAccountService.Domain.ValueObjects;

namespace MarketProject.CustomerAccountService.Domain.Validators
{
    public class EmailValidator : AbstractValidator<string>
    {
        public EmailValidator()
        {
            /*RuleFor(email => email.Value)
                .Length(0, 150)
                .EmailAddress()
                .When(email => email != null);*/

            RuleFor(email => email)
                .MustBeValueObject(email => Email.Create(email))
                .When(email => email != null);
        }
    }
}
