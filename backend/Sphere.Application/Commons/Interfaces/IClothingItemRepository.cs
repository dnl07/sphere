using Sphere.Domain.Clothing;

namespace Sphere.Application.Commons.Interfaces {
    public interface IClothingItemRepository {
        Task AddAsync(ClothingItem item, CancellationToken ct = default);
        Task<ClothingItem?> GetByIdAsync(Guid id, CancellationToken ct = default);
    }
}
