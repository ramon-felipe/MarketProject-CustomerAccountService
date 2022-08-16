using FluentValidation;
using MarketProject.CustomerAccountService.Domain.ValueObjects;

namespace MarketProject.CustomerAccountService.Domain.Validators.CustomValidators
{
    public static class ValueObjectCustomValidator
    {
        public static IRuleBuilderOptions<T, string> MustBeValueObject<T, TValueObject>
            (this IRuleBuilder<T, string> ruleBuilder, 
             Func<string, Result<TValueObject>> factoryMethod) where TValueObject : struct
        {
            return (IRuleBuilderOptions<T, string>)ruleBuilder.Custom((value, context) =>
            {
                if (string.IsNullOrEmpty(value))
                    return;

                Result<TValueObject> result = factoryMethod(value);

                if (result.IsFailure)
                    context.AddFailure(result.Error.Message);
            });
        }

    }
}
