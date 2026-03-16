using Sphere.Application.Commons.Interfaces;
using Sphere.Application.Commons.Interfaces.Repository;
using Sphere.Application.Commons.Interfaces.Services;
using Sphere.Application.Mappers;

namespace Sphere.Application.UseCases.SearchEngine.Command.Search {
    public class SearchHandler : IUseCaseHandler<SearchCommand, SearchResponse> {
        private readonly ISearchEngineService _searchEngine;
        private readonly IClothingItemRepository _clothingRepository;

        public SearchHandler(ISearchEngineService searchEngine, IClothingItemRepository clothingRepository) {
            _searchEngine = searchEngine;
            _clothingRepository = clothingRepository;
        }

        public async Task<SearchResponse> Handle(SearchCommand request, CancellationToken ct) {
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
