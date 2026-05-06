using Microsoft.Extensions.Logging;
using Sphere.Application.Commons.Interfaces;
using Sphere.Application.Commons.Interfaces.Repository;
using Sphere.Application.Commons.Interfaces.Services;
using Sphere.Application.Commons.Models;
using Sphere.Application.Mappers.ClothingItems;
using Sphere.Application.UseCases.ClothingItems.Commons;

namespace Sphere.Application.UseCases.ClothingItems.Queries.GetItems {
    public class GetItemsHandler : IUseCaseHandler<GetItemsQuery, GetItemsResponse> {
        private readonly IClothingItemRepository _clothingRepository;
        private readonly ISearchEngineService _searchEngineService;
        private readonly ILogger<GetItemsHandler> _logger;

        public GetItemsHandler(IClothingItemRepository clothingRepository, ISearchEngineService searchEngineService, ILogger<GetItemsHandler> logger) {
            _clothingRepository = clothingRepository;
            _searchEngineService = searchEngineService;
            _logger = logger;
        }

        public async Task<GetItemsResponse> Handle(GetItemsQuery query, CancellationToken ct) {
            _logger.LogInformation("Retrieving clothing items with filter");

            var filter = query.Filter ?? new ClothingItemFilter();

            if (!string.IsNullOrEmpty(filter.SearchQuery)) {
                var searchResults = await _searchEngineService.SearchAsync(filter.SearchQuery, ct);
                filter.ItemIds = searchResults.ToArray();
            }

            if (filter.CategoryNames != null && filter.CategoryNames.Length > 0) {
                var categories = await _clothingRepository.GetCategoriesByNamesAsync(filter.CategoryNames, ct);
                filter.CategoryIds = categories.Select(c => c.Id).ToArray();
            }

            var pagedItems = await _clothingRepository.GetItemsAsync(filter, ct);
            var meta = await _clothingRepository.GetMetaAsync(filter, ct);

            if (pagedItems.Items.Count == 0) {
                _logger.LogInformation("No clothing items found with the specified filter.");
                return GetItemsResponse.Empty;
            }

            var categoryMap = await CategoryResolver.ResolveAsync(
                pagedItems.Items.Select(i => i.CategoryId).Distinct().ToList(),
                _clothingRepository,
                ct);

            var dtos = pagedItems.Items.Select(i => i.ToDto(categoryMap[i.CategoryId])).ToList();

            var pagedResult = new PagedResult<ClothingItemDto> {
                Items = dtos,
                TotalCount = pagedItems.TotalCount,
                PageCount = pagedItems.PageCount,
                PageNumber = pagedItems.PageNumber,
                HasNextPage = pagedItems.HasNextPage,
                HasPreviousPage = pagedItems.HasPreviousPage
            };

            return new GetItemsResponse(pagedResult, meta);
        }
    }
}
