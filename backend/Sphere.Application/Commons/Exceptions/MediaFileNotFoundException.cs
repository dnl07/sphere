namespace Sphere.Application.Commons.Exceptions {
    public class MediaFileNotFoundException : Exception {
        public MediaFileNotFoundException() { }
        public MediaFileNotFoundException(Guid id) : base($"Media file with id {id} was not found.") { }
        public MediaFileNotFoundException(Guid id, Exception innerException) : base($"Media file with id {id} was not found.", innerException) { }
    }
}
