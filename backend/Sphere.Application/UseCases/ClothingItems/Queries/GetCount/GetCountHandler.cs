using Microsoft.Extensions.Logging;
using Sphere.Application.Commons.Interfaces;
using Sphere.Application.Commons.Interfaces.Repository;
using Sphere.Application.UseCases.ClothingItems.Commons;
using Sphere.Application.UseCases.ClothingItems.Queries.GetItems;

namespace Sphere.Application.UseCases.ClothingItems.Queries.GetCount {
    public class GetCountHandler : IUseCaseHandler<GetCountQuery, GetCountResponse> {
        private readonly IClothingItemRepository _clothingRepository;
        private readonly ILogger<GetItemsHandler> _logger;

        public GetCountHandler(IClothingItemRepository clothingRepository, ILogger<GetItemsHandler> logger) {
            _clothingRepository = clothingRepository;
            _logger = logger;
        }

        public async Task<GetCountResponse> Handle(GetCountQuery query, CancellationToken ct) {
            _logger.LogInformation("Retrieving clothing items count with filter");

            var filter = query.Filter ?? new ClothingItemFilter();

            if (filter.CategoryNames != null && filter.CategoryNames.Length > 0) {
                var categories = await _clothingRepository.GetCategoriesByNamesAsync(filter.CategoryNames, ct);
                filter.CategoryIds = categories.Select(c => c.Id).ToArray();
            }

            var items = await _clothingRepository.GetItemsAsync(filter, ct);

            return new GetCountResponse(items.TotalCount);
        }
    }
}
