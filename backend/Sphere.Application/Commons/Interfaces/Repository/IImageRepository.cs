using Sphere.Domain.Images;

namespace Sphere.Application.Commons.Interfaces.Repository {
    public interface IImageRepository {
        Task <Image?> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task AddAsync(Image image, CancellationToken ct = default);
        Task DeleteAsync(Guid id, CancellationToken ct = default);
    }
}
