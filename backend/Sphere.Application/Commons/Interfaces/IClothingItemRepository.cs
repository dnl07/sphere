using Sphere.Domain.Clothing;

namespace Sphere.Application.Commons.Interfaces {
    public interface IClothingItemRepository {
        Task AddAsync(ClothingItem item);
        Task<ClothingItem> GetByIdAsync(Guid id);
        Task<IEnumerable<ClothingItem>> GetAllAsync();
        Task UpdateAsync(ClothingItem item);
        Task DeleteAsync(Guid id);
    }
}
