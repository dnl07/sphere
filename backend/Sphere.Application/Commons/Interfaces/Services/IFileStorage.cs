namespace Sphere.Application.Commons.Interfaces.Services {
    public interface IFileStorage {
        Task SaveAsync(Guid id, byte[] fileContent, CancellationToken ct = default);
        Task<byte[]> GetAsync(Guid key, CancellationToken ct = default);
        Task DeleteAsync(Guid key, CancellationToken ct = default);
    }
}
