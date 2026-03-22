using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sphere.Application.Commons.Interfaces;
using Sphere.Application.Commons.Interfaces.Repository;
using Sphere.Application.Commons.Models;
using Sphere.Application.UseCases.ClothingItem.Commons;
using Sphere.Domain.Categories;
using Sphere.Domain.ClothingItems;
using Sphere.Infrastructure.Persistance;
using Sphere.Infrastructure.Persistance.Specification;

namespace Sphere.Infrastructure.Repositories {
    public class ClothingItemRepository : IClothingItemRepository {
        private readonly AppDbContext _context;
        private readonly IDomainEventDispatcher _dispatcher;
        private readonly ILogger<ClothingItemRepository> _logger;

        public ClothingItemRepository(AppDbContext context, 
            IDomainEventDispatcher dispatcher, 
            ILogger<ClothingItemRepository> logger) {
            _context = context;
            _dispatcher = dispatcher;
            _logger = logger;
        }

        public async Task SaveChangesAsync(CancellationToken ct = default) {
            await _context.SaveChangesAsync(ct);
        }

        public async Task AddAsync(ClothingItem item, CancellationToken ct = default) {
            await _context.ClothingItems.AddAsync(item, ct);
            await _context.SaveChangesAsync(ct);

            // Dispatch domain events
            await _dispatcher.DispatchAsync(item.DomainEvents, ct);
            item.ClearDomainEvents();

            _logger.LogInformation("Added clothing item with ID {ClothingItemId}", item.Id);
        }

        public async Task<ClothingItem?> GetByIdAsync(Guid id, CancellationToken ct = default) {
            return await _context.ClothingItems
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync(ct);
        }

        public async Task<List<ClothingItem>> GetAllAsync(CancellationToken ct = default) {
            return await _context.ClothingItems
                .ToListAsync(ct);
        }

        public async Task<PagedResult<ClothingItem>> GetFilteredAsync(ClothingItemFilter filter, CancellationToken ct = default) {
            var query = _context.ClothingItems.AsQueryable();

            var spec = new ClothingItemSpecification(filter);
            var items = await spec.Apply(query).ToListAsync(ct);

            _logger.LogInformation("Retrieved {Count} clothing items with filter {filter}", items.Count, filter.Colors);

            return new PagedResult<ClothingItem> {
                Items = items,
                TotalCount = items.Count,
                PageNumber = filter.PageNumber,
                HasNextPage = false,
                HasPreviousPage = false
            };
        }

        public async Task<List<ClothingItem>> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken ct = default) {
            var items = await _context.ClothingItems
                .Where(x => ids.Contains(x.Id))
                .ToListAsync(ct);
            return items;
        }


        public async Task DeleteAsync(Guid id, CancellationToken ct = default) {
            var item = await _context.ClothingItems
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync(ct);

            if (item == null) {
                _logger.LogWarning("Clothing item with ID {ClothingItemId} not found. Skipping deletion.", id);
                return;
            }

            _logger.LogInformation("Deleting clothing item with ID {ClothingItemId}", id);

            // Dispatch domain events before deletion
            await _dispatcher.DispatchAsync(item.DomainEvents, ct);
            item.ClearDomainEvents();

            // Remove the item from the database
            _context.ClothingItems.Remove(item);
            await _context.SaveChangesAsync(ct);
        }

        public async Task<Category?> GetCategoryByIdAsync(Guid id, CancellationToken ct = default) {
            var category = await _context.Categories.FindAsync(new object[] { id }, ct);
            _logger.LogInformation("Retrieved category with ID {CategoryId}: {CategoryName}", id, category?.Name);
            return category;
        }

        public async Task<ClothingItemMeta> GetMetaAsync(ClothingItemFilter filter, CancellationToken ct) {
            var query = _context.ClothingItems.AsQueryable();

            var spec = new ClothingItemSpecification(filter);
            query = spec.Apply(query);

            var totalItems = await query.CountAsync(ct);

            var availableCategoriesIds = await query
                .Select(i => i.CategoryId)
                .Distinct()
                .ToArrayAsync(ct);

            var availableCategories = await _context.Categories
                .Where(c => availableCategoriesIds.Contains(c.Id))
                .GroupBy(c => c.Name)
                .Select(g => new CategoryCount(g.Key, g.Count()))
                .ToArrayAsync(ct);

            var availableColors = await query
                .Where(i => i.Color != null)
                .GroupBy(c => c.Color!)
                .Select(g => new ColorCount(g.Key, g.Count()))
                .ToArrayAsync(ct);

            var availableSizes = await query
                .Where(i => i.Size != null)
                .GroupBy(c => c.Size!)
                .Select(g => new SizeCount(g.Key, g.Count()))
                .ToArrayAsync(ct);

            var availableMaterials = await query
                .Where(i => i.Material != null)
                .GroupBy(c => c.Material!)
                .Select(g => new MaterialCount(g.Key, g.Count()))
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
                totalItems,
                availableCategories,
                availableColors,
                availableSizes,
                availableMaterials,
                minPrice,
                maxPrice
            );
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

        public async Task<List<Category>> GetAllCategoriesAsync(CancellationToken ct = default) {
            return await _context.Categories.ToListAsync(ct);
        }
    }
}
