namespace Sphere.Domain.ClothingItems.Exceptions {
    public class InvalidPriceException : Exception {
        public InvalidPriceException() { }
        public InvalidPriceException(decimal amount, string currency) : base($"Invalid price: {amount} {currency}. Price must be positive and have a valid currency.") { }
        public InvalidPriceException(decimal amount, string currency, Exception innerException) : base($"Invalid price: {amount} {currency}. Price must be positive and have a valid currency.", innerException) { }
    }
}
