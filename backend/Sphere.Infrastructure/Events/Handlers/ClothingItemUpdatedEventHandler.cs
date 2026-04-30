using Microsoft.Extensions.Logging;
using Sphere.Application.Commons.Interfaces;
using Sphere.Application.Commons.Interfaces.Repository;
using Sphere.Application.Commons.Interfaces.Services;
using Sphere.Application.Mappers.ClothingItems;
using Sphere.Domain.ClothingItems.Events;

namespace Sphere.Infrastructure.Events.Handlers {
    public class ClothingItemUpdatedEventHandler : IDomainEventHandler<ClothingItemUpdatedEvent> {
        private readonly ISearchEngineService _searchEngine;
        private readonly IClothingItemRepository _clothingItemRepository;

        private readonly ILogger<ClothingItemUpdatedEventHandler> _logger;

        public ClothingItemUpdatedEventHandler(
            ISearchEngineService searchEngine, 
            IClothingItemRepository clothingItemRepository, 
            ILogger<ClothingItemUpdatedEventHandler> logger) {
            _searchEngine = searchEngine;
            _clothingItemRepository = clothingItemRepository;
            _logger = logger;
        }

        public async Task HandleAsync(ClothingItemUpdatedEvent domainEvent, CancellationToken ct = default) {
            var item = await _clothingItemRepository.GetByIdAsync(domainEvent.ClothingItemId, ct);

            if (item == null) {
                _logger.LogWarning("Clothing item with ID {ClothingItemId} not found. Skipping search engine indexing.", domainEvent.ClothingItemId);
                return;
            }

            var category = await _clothingItemRepository.GetCategoryByIdAsync(item.CategoryId, ct);

            if (category == null) {
                _logger.LogWarning("Category with ID {CategoryId} not found for clothing item {ClothingItemId}. Skipping search engine indexing.", item.CategoryId, item.Id);
                throw new Exception();
            }

            var indexItem = item.ToSearchIndexItem(category.Name);

            var response = await _searchEngine.IndexItemAsync(indexItem, ct);
            _logger.LogInformation("Clothing item indexed with ID {response}", response);
        }
    }
}
