using Microsoft.EntityFrameworkCore;
using Sphere.Application.Commons.Interfaces;
using Sphere.Domain.Clothing;
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
                .FirstOrDefaultAsync(ct);
        }
    }
}
