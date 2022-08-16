using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketProject.CustomerAccountService.Domain.Validators.CustomValidators
{
    public static class StreetCustomValidator
    {
        public static IRuleBuilderOptions<T, string> StreetNameShouldStartWith<T>(this IRuleBuilderOptions<T, string> ruleBuilder, string prefix)
        {
            return ruleBuilder
                .Must(s => s.StartsWith(prefix))
                .WithMessage($"Street's name must start with {prefix}");
        }

    }
}
