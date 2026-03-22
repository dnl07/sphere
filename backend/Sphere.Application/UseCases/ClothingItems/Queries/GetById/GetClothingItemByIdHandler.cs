using Sphere.Application.Commons.Exceptions;
using Sphere.Application.Commons.Interfaces;
using Sphere.Application.Commons.Interfaces.Repository;
using Sphere.Application.Mappers.ClothingItems;
using Sphere.Application.UseCases.ClothingItems.Commons;

namespace Sphere.Application.UseCases.ClothingItems.Queries.GetById {
    public class GetClothingItemByIdHandler : IUseCaseHandler<GetClothingItemByIdQuery, ClothingItemDto> {
        private readonly IClothingItemRepository _repository;

        public GetClothingItemByIdHandler(IClothingItemRepository repository) {
            _repository = repository;
        }

        public async Task<ClothingItemDto> Handle(GetClothingItemByIdQuery request, CancellationToken ct) {
            var response = await _repository.GetByIdAsync(request.Id, ct);

            if (response == null) {
                throw new ClothingItemNotFoundException(request.Id);
            }

            var category = await _repository.GetCategoryByIdAsync(response.CategoryId, ct);

            if (category == null) {
                throw new CategoryNotFoundException(response.CategoryId);
            }

            return response.ToDto(category.Name);
        }
    }
}