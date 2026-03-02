namespace Sphere.Domain.Clothing.ValueObjects {
    public class Price {
        public decimal Amount { get; }
        public string Currency { get; }

        public Price(decimal amount, string currency) {
            if (amount < 0) {
                throw new ArgumentException("Price cannot be negative.");
            }

            if (string.IsNullOrWhiteSpace(currency)) {
                throw new ArgumentException("Currency cannot be empty.");
            }
            Amount = amount;
            Currency = currency;
        }

        public override bool Equals(object? obj) => obj is Price price && Amount == price.Amount && Currency == price.Currency;
        public override int GetHashCode() => HashCode.Combine(Amount, Currency);
        public override string ToString() => $"{Amount} {Currency}";
    }
}
