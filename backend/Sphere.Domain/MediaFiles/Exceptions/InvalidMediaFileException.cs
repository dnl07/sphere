namespace Sphere.Domain.Images.Exceptions {
    public class InvalidMediaFileException : Exception {
        public InvalidMediaFileException() { }
        public InvalidMediaFileException(string message) : base(message) { }
        public InvalidMediaFileException(string message, Exception innerException) : base(message, innerException) { }
    }
}
