using Sphere.Domain.Clothing;
using Sphere.Domain.ClothingImages;

namespace Sphere.Application.Commons.Interfaces {
    public interface IClothingItemRepository {
        Task AddAsync(ClothingItem item, CancellationToken ct = default);
        Task<ClothingItem?> GetByIdAsync(Guid id, CancellationToken ct = default);
    }
}
