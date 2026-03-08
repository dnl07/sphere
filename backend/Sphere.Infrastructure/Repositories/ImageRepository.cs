using Microsoft.EntityFrameworkCore;
using Sphere.Application.Commons.Interfaces.Repository;
using Sphere.Domain.Images;
using Sphere.Infrastructure.Persistance;

namespace Sphere.Infrastructure.Repositories {
    public class ImageRepository : IImageRepository {
        private readonly AppDbContext _context;

        public ImageRepository(AppDbContext context) {
            _context = context;
        }

        public async Task AddAsync(Image image, CancellationToken ct = default) {
            await _context.Images.AddAsync(image, ct);
            await _context.SaveChangesAsync(ct);
        }

        public async Task<Image?> GetByIdAsync(Guid id, CancellationToken ct = default) {
            var item = await _context.Images
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync(ct);

            return item;
        }

        public async Task DeleteAsync(Guid id, CancellationToken ct = default) {
            var item = await _context.Images
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync(ct);

            if (item != null) {
                _context.Images.Remove(item);
                await _context.SaveChangesAsync(ct);
            }
        }
    }
}
