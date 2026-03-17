using Sphere.Application.Commons.Exceptions;
using Sphere.Application.Commons.Interfaces;
using Sphere.Application.Commons.Interfaces.Repository;
using Sphere.Application.Mappers.ClothingItems;
using Sphere.Application.UseCases.ClothingItems.Queries.Get;
using Sphere.Application.UseCases.ClothingItems.Queries.GetAll;

namespace Sphere.Application.UseCases.ClothingItem.Queries.GetAll {
    public class GetAllClothingItemHandler : IUseCaseHandler<GetAllClothingItemQuery, GetAllClothingItemResponse> {
        private readonly IClothingItemRepository _repository;

        public GetAllClothingItemHandler(IClothingItemRepository repository) {
            _repository = repository;
        }

        public async Task<GetAllClothingItemResponse> Handle(GetAllClothingItemQuery query, CancellationToken ct) {

            var items = await _repository.GetAllAsync(ct);

            if (items.Count == 0) {
                return new GetAllClothingItemResponse([]);
            }

            var clothingResponses = new List<GetClothingItemResponse>();

            // Todo: Optimize this
            foreach (var item in items) {
                var category = await _repository.GetCategoryByIdAsync(item.CategoryId, ct);

                if (category == null) {
                    throw new CategoryNotFoundException(item.CategoryId);
                }

                clothingResponses.Add(item.ToGetResponse(category.Name));
            }

            return new GetAllClothingItemResponse(clothingResponses);
        }
    }
}