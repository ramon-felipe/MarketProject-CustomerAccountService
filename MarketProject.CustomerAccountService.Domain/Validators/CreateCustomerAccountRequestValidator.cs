using FluentValidation;
using MarketProject.CustomerAccountService.Domain.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketProject.CustomerAccountService.Domain.Validators
{
    public class CreateCustomerAccountRequestValidator : AbstractValidator<CreateCustomerAccountRequestModel>
    {
        public CreateCustomerAccountRequestValidator()
        {
            RuleFor(_ => _.CustomerId)
                .GreaterThan(0)
                .WithMessage(_ => $"{nameof(_.CustomerId)} should be greater than zero");

            RuleFor(_ => _.Address)
                .NotNull()
                .WithMessage(_ => $"{nameof(_.Address)} is null")
                .SetValidator(new AddressValidator());

            /*RuleFor(_ => _.Email)
                .NotEmpty()
                .SetValidator(new EmailValidator());*/

            RuleFor(_ => _.Email)
                .NotEmpty()
                .MaximumLength(50)
                .EmailAddress();
        }
    }
}
