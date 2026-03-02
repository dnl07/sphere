using Microsoft.EntityFrameworkCore;
using Sphere.Application.Commons.Interfaces.Repository;
using Sphere.Domain.Clothing;
using Sphere.Domain.ClothingImages;
using Sphere.Infrastructure.Persistance;

namespace Sphere.Infrastructure.Repositories {
    public class ClothingItemRepository : IClothingItemRepository {
        private readonly AppDbContext _context;

        public ClothingItemRepository(AppDbContext context) {
            _context = context;
        }

        public async Task AddAsync(ClothingItem item, CancellationToken ct = default) {
            await _context.ClothingItems.AddAsync(item, ct);
            await _context.SaveChangesAsync(ct);
        }

        public async Task<ClothingItem?> GetByIdAsync(Guid id, CancellationToken ct = default) {
            return await _context.ClothingItems
                .Where(x => x.Id == id)
                .Include(x => x.Image)
                .FirstOrDefaultAsync(ct);
        }

        public async Task<List<ClothingItem>> GetAllAsync(CancellationToken ct = default) {
            return await _context.ClothingItems
                .Include(x => x.Image)
                .ToListAsync(ct);
        }

        public async Task DeleteAsync(Guid id, CancellationToken ct = default) {
            var item = await _context.ClothingItems
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync(ct);

            if (item != null) {
                _context.ClothingItems.Remove(item);
                await _context.SaveChangesAsync(ct);
            }
        }
    }
}
