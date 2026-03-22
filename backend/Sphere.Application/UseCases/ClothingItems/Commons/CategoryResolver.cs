using Sphere.Application.Commons.Interfaces.Repository;

namespace Sphere.Application.UseCases.ClothingItems.Commons {
    public static class CategoryResolver {
        public static async Task<Dictionary<Guid, string>> ResolveAsync(
            IEnumerable<Guid> categoryIds, 
            IClothingItemRepository repository, 
            CancellationToken ct = default) {
            var ids = categoryIds.Distinct().ToList();
            var categories = await repository.GetCategoriesByIdsAsync(ids, ct);
            return categories.ToDictionary(c => c.Id, c => c.Name);
        }
    }
}
