using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sphere.Application.Commons.Interfaces.Repository;
using Sphere.Domain.Images;
using Sphere.Infrastructure.Persistance;

namespace Sphere.Infrastructure.Repositories {
    public class ImageRepository : IImageRepository {
        private readonly AppDbContext _context;
        private readonly ILogger<ImageRepository> _logger;

        public ImageRepository(AppDbContext context, ILogger <ImageRepository> logger) {
            _context = context;
            _logger = logger;
        }

        public async Task AddAsync(Image image, CancellationToken ct = default) {
            await _context.Images.AddAsync(image, ct);
            await _context.SaveChangesAsync(ct);

            _logger.LogInformation("Added image with ID {ImageId}", image.Id);
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

            if (item == null) {
                _logger.LogWarning("Image with ID {ImageId} not found. Skipping deletion.", id);
                return;
            }

            _logger.LogInformation("Deleting image with ID {ImageId}", item.Id);

            _context.Images.Remove(item);
            await _context.SaveChangesAsync(ct);
        }
    }
}
