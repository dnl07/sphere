using Sphere.Application.Commons.Models;
using Sphere.Application.UseCases.ClothingItems.Commons;
using Sphere.Domain.Categories;
using Sphere.Domain.ClothingItems;

namespace Sphere.Application.Commons.Interfaces.Repository {
    public interface IClothingItemRepository {
        Task SaveChangesAsync(CancellationToken ct = default);

        // Clothing Item CRUD
        Task AddAsync(ClothingItem item, CancellationToken ct = default);
        Task<ClothingItem?> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task<PagedResult<ClothingItem>> GetItemsAsync(ClothingItemFilter filter, CancellationToken ct = default);
        Task<List<ClothingItem>> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken ct = default);
        Task DeleteAsync(Guid id, CancellationToken ct = default);
        Task<ClothingItemMeta> GetMetaAsync(ClothingItemFilter filter, CancellationToken ct = default);

        // Category
        Task<Category?> GetCategoryByIdAsync(Guid id, CancellationToken ct = default);
        Task<List<Category>> GetCategoriesByIdsAsync(IEnumerable<Guid> ids, CancellationToken ct = default);
        Task<Category?> GetCategoryByNameAsync(string name, CancellationToken ct = default);
        Task<List<Category>> GetCategoriesByNamesAsync(IEnumerable<string> names, CancellationToken ct = default);

        Task<List<Category>> GetAllCategoriesAsync(CancellationToken ct = default);

    }
}
