using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sphere.Application.Commons.Interfaces.Repository;
using Sphere.Application.Commons.Models;
using Sphere.Domain.ClothingItems;
using Sphere.Infrastructure.Persistance.Specification;
using Sphere.Application.UseCases.ClothingItems.Commons;

namespace Sphere.Infrastructure.Repositories {
    public partial class ClothingItemRepository : IClothingItemRepository {
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

        public async Task<PagedResult<ClothingItem>> GetItemsAsync(ClothingItemFilter filter, CancellationToken ct = default) {
            var query = _context.ClothingItems.AsQueryable();
            var spec = new ClothingItemSpecification(filter);

            var totalCount = await spec.Apply(query).CountAsync(ct);
            var items = await spec.ApplyPagination(query).ToListAsync(ct);

            var totalPages = (int)Math.Ceiling((double)totalCount / filter.PageSize);

            _logger.LogInformation("Retrieved {Count} clothing items", items.Count);

            return new PagedResult<ClothingItem> {
                Items = items,
                TotalCount = totalCount,
                PageCount = items.Count,
                PageNumber = filter.PageNumber,
                HasNextPage = filter.PageNumber < totalPages,
                HasPreviousPage = filter.PageNumber > 1
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
    }
}
