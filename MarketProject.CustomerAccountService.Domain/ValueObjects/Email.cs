using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MarketProject.CustomerAccountService.Domain.ValueObjects
{
    public record struct Email
    {
        [EmailAddress]
        public string Value { get; private set; }

        private Email(string value)
        {
            Value = value;
        }

        public static Result<Email> Create(string email)
        {
            if (string.IsNullOrEmpty(email))
                return Result.Failure<Email>(ResultError.Create($"{nameof(email)} value is required."));

            var _email = email.Trim();

            if (_email.Length > 150)
                return Result.Failure<Email>(ResultError.Create("Email is too long."));

            if (!Regex.IsMatch(_email, @"^(.+)@(.+)$"))
                return Result.Failure<Email>(ResultError.Create("Invalid email."));

            return Result.Success(new Email(_email));
        }
    }
}
