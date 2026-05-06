using Microsoft.Extensions.Logging;
using Sphere.Application.Commons.Interfaces;
using Sphere.Application.Commons.Interfaces.Repository;
using Sphere.Application.Commons.Interfaces.Services;
using Sphere.Application.Mappers.ClothingItems;

namespace Sphere.Application.UseCases.Search.Command.Search {
    public class SearchHandler : IUseCaseHandler<SearchCommand, SearchResponse> {
        private readonly ISearchEngineService _searchEngine;
        private readonly IClothingItemRepository _clothingRepository;
        private readonly ILogger<SearchHandler> _logger;

        public SearchHandler(ISearchEngineService searchEngine, IClothingItemRepository clothingRepository, ILogger<SearchHandler> logger) {
            _searchEngine = searchEngine;
            _clothingRepository = clothingRepository;
            _logger = logger;
        }

        public async Task<SearchResponse> Handle(SearchCommand request, CancellationToken ct) {
            _logger.LogInformation("Performing search with query: {Query}", request.Query);

            var ids = await _searchEngine.SearchAsync(request.Query, ct);

            var items = await _clothingRepository.GetByIdsAsync(ids, ct);

            var categoryIds = items.Select(i => i.CategoryId).Distinct().ToList();
            var categories = await _clothingRepository.GetCategoriesByIdsAsync(categoryIds, ct);

            var ordered = ids
                .Select(id => items.FirstOrDefault(i => i.Id == id))
                .Where(item => item != null)
                .Select(item => {
                    var categoryName = categories.FirstOrDefault(c => c.Id == item!.CategoryId)?.Name;
                    return item!.ToSearchResult(categoryName);
                })
                .ToArray();

            return new SearchResponse(ordered);
        }
    }
}
