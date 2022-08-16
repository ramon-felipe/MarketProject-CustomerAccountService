namespace MarketProject.CustomerAccountService.Domain.ValueObjects
{
    // public record Address(string Street);

    public record struct Address
    {
        public string Street { get; private set; }

        private Address(string street)
        {
            Street = street;
        }

        public static Result<Address> Create(string street)
        {
            if (string.IsNullOrEmpty(street))
                return Result.Failure<Address>(ResultError.Create("Street is null or empty", new ArgumentNullException("Street is null or empty")));

            if(street.Length < 10)
                return Result.Failure<Address>(ResultError.Create("Street name is too short."));

            if(street.Length > 100)
                return Result.Failure<Address>(ResultError.Create("Street name is too long."));

            if(!street.ToLower().StartsWith("rua"))
                return Result.Failure<Address>(ResultError.Create("Street name must start with 'rua'."));

            return Result.Success(new Address(street));
        }
    }
}