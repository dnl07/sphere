namespace Sphere.Domain.Categories.Exceptions {
    public class InvalidCategoryException : Exception {
        public InvalidCategoryException() { }
        public InvalidCategoryException(string categoryName) : base($"Category '{categoryName}' is invalid or does not exist") { }
        public InvalidCategoryException(string categoryName, Exception innerException) : base($"Category '{categoryName}' is invalid or does not exist", innerException) { }
    }
}
