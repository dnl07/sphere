using Sphere.Application.Commons.Interfaces;
using Sphere.Application.Commons.Interfaces.Repository;
using Sphere.Application.Commons.Models;
using Sphere.Application.Mappers.ClothingItems;
using Sphere.Application.UseCases.ClothingItems.Commons;

namespace Sphere.Application.UseCases.ClothingItems.Queries.GetItems {
    public class GetItemsHandler : IUseCaseHandler<GetItemsQuery, GetItemsResponse> {
        private readonly IClothingItemRepository _clothingRepository;

        public GetItemsHandler(IClothingItemRepository clothingRepository) {
            _clothingRepository = clothingRepository;
        }

        public async Task<GetItemsResponse> Handle(GetItemsQuery query, CancellationToken ct) {
            var filter = query.Filter ?? new ClothingItemFilter();

            if (filter.CategoryNames != null && filter.CategoryNames.Length > 0) {
                var categories = await _clothingRepository.GetCategoriesByNamesAsync(filter.CategoryNames, ct);
                filter.CategoryIds = categories.Select(c => c.Id).ToArray();
            }

            var pagedItems = await _clothingRepository.GetItemsAsync(filter, ct);
            var meta = await _clothingRepository.GetMetaAsync(filter, ct);

            if (pagedItems.Items.Count == 0) {
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
                PageNumber = pagedItems.PageNumber,
                HasNextPage = pagedItems.HasNextPage,
                HasPreviousPage = pagedItems.HasPreviousPage
            };

            return new GetItemsResponse(pagedResult, meta);
        }
    }
}
