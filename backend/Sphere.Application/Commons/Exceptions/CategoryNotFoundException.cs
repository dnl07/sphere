namespace Sphere.Application.Commons.Exceptions {
    public class CategoryNotFoundException : Exception {
        public CategoryNotFoundException() { }
        public CategoryNotFoundException(Guid id) : base($"Category with id {id} was not found.") { }
        public CategoryNotFoundException(string name) : base($"Category with id {name} was not found.") { }
        public CategoryNotFoundException(Guid id, Exception innerException) : base($"Clothing with id {id} was not found.", innerException) { }
        public CategoryNotFoundException(string name, Exception innerException) : base($"Clothing with id {name} was not found.", innerException) { }
    }
}
