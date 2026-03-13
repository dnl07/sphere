namespace Sphere.Application.Commons.Interfaces.Services {
    public interface IBackgroundRemoverService {
        Task<byte[]> RemoveBackgroundAsync(byte[] imageData, CancellationToken ct = default);
    }
}
