using Microsoft.EntityFrameworkCore;
using Sphere.Application.Commons.Interfaces.Repository;
using Sphere.Infrastructure.Persistance.Specification;
using Sphere.Application.UseCases.ClothingItems.Commons;

namespace Sphere.Infrastructure.Repositories {
    public partial class ClothingItemRepository : IClothingItemRepository {
        public async Task<ClothingItemMeta> GetMetaAsync(ClothingItemFilter filter, CancellationToken ct) {
            var query = _context.ClothingItems.AsQueryable();

            var spec = new ClothingItemSpecification(filter);
            query = spec.Apply(query);

            var totalItems = await query.CountAsync(ct);

            var availableCategoriesIds = await query
                .Select(i => i.CategoryId)
                .Distinct()
                .ToArrayAsync(ct);

            var availableCategories = await query
                .GroupBy(i => i.CategoryId)
                .Select(g => new { CategoryId = g.Key, Count = g.Count() })
                .Join(_context.Categories,
                    g => g.CategoryId,
                    c => c.Id,
                    (g, c) => new FilterOption(c.Name, g.Count))
                .ToArrayAsync(ct);

            var availableColors = await query
                .Where(i => i.Color != null)
                .GroupBy(c => c.Color!)
                .Select(g => new FilterOption(g.Key, g.Count()))
                .ToArrayAsync(ct);

            var availableSizes = await query
                .Where(i => i.Size != null)
                .GroupBy(c => c.Size!)
                .Select(g => new FilterOption(g.Key, g.Count()))
                .ToArrayAsync(ct);

            var availableMaterials = await query
                .Where(i => i.Material != null)
                .GroupBy(c => c.Material!)
                .Select(g => new FilterOption(g.Key, g.Count()))
                .ToArrayAsync(ct);

            var minPrice = await query
                .Where(i => i.Price != null)
                .Select(i => (decimal?)i.Price!.Amount)
                .MinAsync(ct);

            var maxPrice = await query
                .Where(i => i.Price != null)
                .Select(i => (decimal?)i.Price!.Amount)
                .MaxAsync(ct);

            return new ClothingItemMeta(
                availableCategories,
                availableColors,
                availableSizes,
                availableMaterials,
                minPrice,
                maxPrice
            );
        }
    }
}
