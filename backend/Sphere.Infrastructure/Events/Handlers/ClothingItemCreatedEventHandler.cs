using Microsoft.Extensions.Logging;
using Sphere.Application.Commons.Interfaces;
using Sphere.Application.Commons.Interfaces.Repository;
using Sphere.Application.Commons.Interfaces.Services;
using Sphere.Domain.ClothingItems.Events;

namespace Sphere.Infrastructure.Events.Handlers {
    public class ClothingItemCreatedEventHandler : IDomainEventHandler<ClothingItemCreatedEvent> {
        private readonly ISearchEngineService _searchEngine;
        private readonly IClothingItemRepository _clothingItemRepository;

        private readonly ILogger<ClothingItemCreatedEventHandler> _logger;

        public ClothingItemCreatedEventHandler(
            ISearchEngineService searchEngine, 
            IClothingItemRepository clothingItemRepository, 
            ILogger<ClothingItemCreatedEventHandler> logger) {
            _searchEngine = searchEngine;
            _clothingItemRepository = clothingItemRepository;
            _logger = logger;
        }

        public async Task HandleAsync(ClothingItemCreatedEvent domainEvent, CancellationToken ct = default) {
            var item = await _clothingItemRepository.GetByIdAsync(domainEvent.ClothingItemId, ct);

            if (item == null) {
                _logger.LogInformation("Clothing item with ID {ClothingItemId} not found. Skipping search engine indexing.", domainEvent.ClothingItemId);
                return;
            }

            var indexItem = new SearchIndexItem {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description
            };

            var response = await _searchEngine.IndexItemAsync(indexItem, ct);
            _logger.LogInformation("Clothing got id {response}", response);
        }
    }
}
