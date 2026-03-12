using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sphere.Application.Commons.Interfaces;
using Sphere.Application.Commons.Interfaces.Repository;
using Sphere.Domain.Categories;
using Sphere.Domain.ClothingItems;
using Sphere.Infrastructure.Persistance;

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
            return await _context.Categories.FindAsync(new object[] { id }, ct);
        }

        public async Task<Category?> GetCategoryByNameAsync(string name, CancellationToken ct = default) {
            string normalized = name.ToLower();

            return await _context.Categories.FirstOrDefaultAsync(c => c.Name.Equals(normalized, StringComparison.CurrentCultureIgnoreCase), ct);
        }

        public async Task<List<Category>> GetAllCategoriesAsync(CancellationToken ct = default) {
            return await _context.Categories.ToListAsync(ct);
        }
    }
}
