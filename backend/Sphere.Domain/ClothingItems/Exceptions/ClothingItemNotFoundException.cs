namespace Sphere.Domain.Clothing.Exceptions {
    public class ClothingItemNotFoundException : Exception {
        public ClothingItemNotFoundException() { }
        public ClothingItemNotFoundException(Guid id) : base($"Clothing with id {id} was not found.") { }
        public ClothingItemNotFoundException(Guid id, Exception innerException) : base($"Clothing with id {id} was not found.", innerException) { }
    }
}
