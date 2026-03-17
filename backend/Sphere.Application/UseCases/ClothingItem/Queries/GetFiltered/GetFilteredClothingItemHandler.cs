using Sphere.Application.Commons.Interfaces;
using Sphere.Application.Commons.Interfaces.Repository;
using Sphere.Application.UseCases.ClothingItem.Commons;
using Sphere.Application.Commons.Exceptions;
using Sphere.Application.Mappers.ClothingItems;

namespace Sphere.Application.UseCases.ClothingItem.Queries.GetFiltered {
    public class GetFilteredClothingItemHandler : IUseCaseHandler<GetFilteredClothingItemQuery, GetFilteredClothingItemResponse> {
        private readonly IClothingItemRepository _repository;

        public GetFilteredClothingItemHandler(IClothingItemRepository repository) {
            _repository = repository;
        }

        public async Task<GetFilteredClothingItemResponse> Handle(GetFilteredClothingItemQuery query, CancellationToken ct) {
            var pagedResult = await _repository.GetFilteredAsync(query.Filter, ct);

            if (pagedResult.Items.Count == 0) {
                return GetFilteredClothingItemResponse.Empty();
            }

            var categoryMap = await CategoryResolver.ResolveAsync(
                pagedResult.Items.Select(i => i.CategoryId).Distinct().ToList(),
                _repository,
                ct);

            var dtos = pagedResult.Items.Select(i => {
                if (!categoryMap.TryGetValue(i.CategoryId, out var categoryName)) {
                    throw new CategoryNotFoundException(i.CategoryId);
                }
                return i.ToGetResponse(categoryName);
            }).ToList();

            return new GetFilteredClothingItemResponse(
                dtos,
                pagedResult.TotalCount,
                query.Filter.PageNumber,
                pagedResult.HasNextPage,
                pagedResult.HasPreviousPage
            );
        }
    }
}
