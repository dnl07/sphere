using Sphere.Application.Commons.Exceptions;
using Sphere.Application.Commons.Interfaces;
using Sphere.Application.Commons.Interfaces.Repository;
using Sphere.Application.Mappers;
using Sphere.Application.UseCases.ClothingItems.Queries.Get;

namespace Sphere.Application.UseCases.ClothingItems.Queries.GetAll {
    public class GetAllClothingItemHandler : IUseCaseHandler<GetAllClothingItemQuery, GetAllClothingItemResponse> {
        private readonly IClothingItemRepository _repository;

        public GetAllClothingItemHandler(IClothingItemRepository repository) {
            _repository = repository;
        }

        public async Task<GetAllClothingItemResponse> Handle(GetAllClothingItemQuery request, CancellationToken ct) {
            var items = await _repository.GetAllAsync(ct);

            if (items.Count == 0) {
                throw new NotFoundException($"No clothing items found.");
            }

            var clothingResponses = new List<GetClothingItemResponse>();

            foreach (var item in items) {
                var category = await _repository.GetCategoryByIdAsync(item.CategoryId, ct);

                if (category == null) {
                    throw new NotFoundException($"Category with ID {item.CategoryId} not found for clothing item with ID {item.Id}.");
                }

                clothingResponses.Add(item.ToGetResponse(category.Name));
            }

            return new GetAllClothingItemResponse(clothingResponses);
        }
    }
}