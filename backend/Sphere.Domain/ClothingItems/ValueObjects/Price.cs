using Sphere.Domain.Clothing.Exceptions;

namespace Sphere.Domain.ClothingItems.ValueObjects {
    public class Price {
        public decimal Amount { get; }
        public string Currency { get; }

        public Price(decimal amount, string currency) {
            Amount = amount;
            Currency = currency;

            Validate();
        }

        public override bool Equals(object? obj) => obj is Price price && Amount == price.Amount && Currency == price.Currency;
        public override int GetHashCode() => HashCode.Combine(Amount, Currency);
        public override string ToString() => $"{Amount} {Currency}";

        private void Validate() {
            if (Amount < 0) {
                throw new InvalidPriceException(Amount, Currency);
            }

            if (string.IsNullOrWhiteSpace(Currency)) {
                throw new InvalidPriceException(Amount, Currency);
            }
        }
    }
}
