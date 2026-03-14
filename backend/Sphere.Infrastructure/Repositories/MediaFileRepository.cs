using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sphere.Application.Commons.Interfaces.Repository;
using Sphere.Domain.MediaFiles;
using Sphere.Infrastructure.Persistance;

namespace Sphere.Infrastructure.Repositories {
    public class MediaFileRepository : IMediaFileRepository {
        private readonly AppDbContext _context;
        private readonly ILogger<MediaFileRepository> _logger;

        public MediaFileRepository(AppDbContext context, ILogger<MediaFileRepository> logger) {
            _context = context;
            _logger = logger;
        }

        public async Task AddAsync(MediaFile image, CancellationToken ct = default) {
            await _context.MediaFiles.AddAsync(image, ct);
            await _context.SaveChangesAsync(ct);

            _logger.LogInformation("Added image with ID {ImageId}", image.Id);
        }

        public async Task<MediaFile?> GetByIdAsync(Guid id, CancellationToken ct = default) {
            var item = await _context.MediaFiles
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync(ct);

            return item;
        }

        public async Task DeleteAsync(Guid id, CancellationToken ct = default) {
            var item = await _context.MediaFiles
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync(ct);

            if (item == null) {
                _logger.LogWarning("Image with ID {ImageId} not found. Skipping deletion.", id);
                return;
            }

            _logger.LogInformation("Deleting image with ID {ImageId}", item.Id);

            _context.MediaFiles.Remove(item);
            await _context.SaveChangesAsync(ct);
        }
    }
}
