using Sphere.Domain.Clothing;

namespace Sphere.Application.Commons.Interfaces.Repository {
    public interface IClothingItemRepository {
        Task AddAsync(ClothingItem item, CancellationToken ct = default);
        Task<ClothingItem?> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task<List<ClothingItem>> GetAllAsync(CancellationToken ct = default);
        Task DeleteAsync(Guid id, CancellationToken ct = default);
    }
}
