using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sphere.Application.Commons.Interfaces.Repository;
using Sphere.Domain.Categories;
using Sphere.Application.Commons.Exceptions;

namespace Sphere.Infrastructure.Repositories {
    public partial class ClothingItemRepository : IClothingItemRepository {
        public async Task<Category?> GetCategoryByIdAsync(Guid id, CancellationToken ct = default) {
            var category = await _context.Categories.FindAsync(new object[] { id }, ct);
            _logger.LogInformation("Retrieved category with ID {CategoryId}: {CategoryName}", id, category?.Name);
            return category;
        }

        public async Task<List<Category>> GetCategoriesByIdsAsync(IEnumerable<Guid> ids, CancellationToken ct = default) {
            var categories = await _context.Categories
                .Where(c => ids.Contains(c.Id))
                .ToListAsync(ct);
            return categories;
        }

        public async Task<Category?> GetCategoryByNameAsync(string name, CancellationToken ct = default) {
            string normalized = name.ToLower();

            return await _context.Categories.FirstOrDefaultAsync(c => c.Name.ToLower() == normalized.ToLower(), ct);
        }

        public async Task<List<Category>> GetCategoriesByNamesAsync(IEnumerable<string> names, CancellationToken ct = default) {
            var namesList = names.ToList();

            var categories = await _context.Categories
                .Where(c => namesList.Contains(c.Name))
                .ToListAsync(ct);
            
            var notFound = namesList.Except(categories.Select(c => c.Name)).ToList();

            if (notFound.Count > 0) {
                _logger.LogWarning("Categories not found: {NotFoundCategories}", string.Join(", ", notFound));
                throw new CategoryNotFoundException(notFound[0]);
            }

            return categories;
        }

        public async Task<List<Category>> GetAllCategoriesAsync(CancellationToken ct = default) {
            return await _context.Categories.ToListAsync(ct);
        }
    }
}
