namespace Sphere.Application.Commons.Interfaces.Services {
    public interface IImageProcessingService {
        public Task<byte[]> ProcessImage(byte[] imageBytes, CancellationToken ct);
    }
}