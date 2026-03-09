using Microsoft.Extensions.Logging;
using Sphere.Application.Commons.Interfaces;
using Sphere.Application.Commons.Interfaces.Repository;
using Sphere.Application.Commons.Interfaces.Services;
using Sphere.Domain.ClothingItems.Events;

namespace Sphere.Infrastructure.Events.Handlers {
    public class ClothingItemDeletedEventHandler : IDomainEventHandler<ClothingItemDeletedEvent> {
        private readonly ISearchEngineService _searchEngine;
        private readonly IClothingItemRepository _clothingItemRepository;
        private readonly IFileStorage _fileStorage;

        private readonly ILogger<ClothingItemCreatedEventHandler> _logger;

        public ClothingItemDeletedEventHandler(
            ISearchEngineService searchEngine,
            IClothingItemRepository clothingItemRepository,
            ILogger<ClothingItemCreatedEventHandler> logger,
            IFileStorage fileStorage) {
            _searchEngine = searchEngine;
            _clothingItemRepository = clothingItemRepository;
            _logger = logger;
            _fileStorage = fileStorage;
        }

        public async Task HandleAsync(ClothingItemDeletedEvent domainEvent, CancellationToken ct = default) {
            var item = await _clothingItemRepository.GetByIdAsync(domainEvent.ClothingItemId, ct);

            if (item == null) {
                _logger.LogWarning("Clothing item with ID {ClothingItemId} not found. Skipping search engine indexing.", domainEvent.ClothingItemId);
                return;
            }

            await _searchEngine.RemoveItemAsync(item.Id, ct);
            await _fileStorage.DeleteAsync(item.ImageId, ct);

            _logger.LogInformation("Clothing deleted with id {id}", item.Id);
        }
    }
}
