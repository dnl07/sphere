using Microsoft.Extensions.Logging;
using Sphere.Application.Commons.Interfaces;
using Sphere.Application.Commons.Interfaces.Repository;
using Sphere.Infrastructure.Persistance;

namespace Sphere.Infrastructure.Repositories {
    public partial class ClothingItemRepository : IClothingItemRepository {
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
    }
}
