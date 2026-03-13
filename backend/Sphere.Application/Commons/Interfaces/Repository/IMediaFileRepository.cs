using Sphere.Domain.MediaFiles;

namespace Sphere.Application.Commons.Interfaces.Repository {
    public interface IMediaFileRepository {
        Task <MediaFile?> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task AddAsync(MediaFile image, CancellationToken ct = default);
        Task DeleteAsync(Guid id, CancellationToken ct = default);
    }
}
