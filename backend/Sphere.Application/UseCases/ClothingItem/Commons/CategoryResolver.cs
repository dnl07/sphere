using Sphere.Application.Commons.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sphere.Application.UseCases.ClothingItem.Commons {
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
