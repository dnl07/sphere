namespace Sphere.Application.Commons.Interfaces {
    public interface IFileStorage {
        Task<bool> SaveAsync(Guid id, byte[] fileContent, CancellationToken ct = default);
        Task<byte[]> GetAsync(Guid key, CancellationToken ct = default);
        Task DeleteAsync(Guid key, CancellationToken ct = default);
    }
}
