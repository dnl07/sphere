using Sphere.Application.UseCases.ClothingItem.Queries.GetMeta;
using Sphere.Domain.Categories;
using Sphere.Domain.ClothingItems;

namespace Sphere.Application.Commons.Interfaces.Repository {
    public interface IClothingItemRepository {
        Task SaveChangesAsync(CancellationToken ct = default);

        // Clothing Item CRUD
        Task AddAsync(ClothingItem item, CancellationToken ct = default);
        Task<ClothingItem?> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task<List<ClothingItem>> GetAllAsync(CancellationToken ct = default);
        Task<List<ClothingItem>> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken ct = default);
        Task DeleteAsync(Guid id, CancellationToken ct = default);
        Task<ClothingItemMeta> GetMetaAsync(CancellationToken ct = default);

        // Category
        Task<Category?> GetCategoryByIdAsync(Guid id, CancellationToken ct = default);
        Task<List<Category>> GetCategoriesByIdsAsync(IEnumerable<Guid> ids, CancellationToken ct = default);
        Task<Category?> GetCategoryByNameAsync(string name, CancellationToken ct = default);
        Task<List<Category>> GetAllCategoriesAsync(CancellationToken ct = default);

    }
}
