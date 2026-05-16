namespace Sphere.Domain.ClothingItems.Exceptions {
    public class InvalidPriceException : Exception {
        public InvalidPriceException() { }
        public InvalidPriceException(decimal amount) : base($"Invalid price: {amount}. Price must be positive.") { }
        public InvalidPriceException(decimal amount, Exception innerException) : base($"Invalid price: {amount}. Price must be positive.", innerException) { }
    }
}
