using Sphere.Application.Commons.Exceptions;
using Sphere.Application.Commons.Interfaces;
using Sphere.Application.Commons.Interfaces.Repository;
using Sphere.Application.Mappers.ClothingItems;

namespace Sphere.Application.UseCases.ClothingItems.Queries.Get {
    public class GetByIdHandler : IUseCaseHandler<GetByIdQuery, GetByIdResponse> {
        private readonly IClothingItemRepository _repository;

        public GetByIdHandler(IClothingItemRepository repository) {
            _repository = repository;
        }

        public async Task<GetByIdResponse> Handle(GetByIdQuery request, CancellationToken ct) {
            var response = await _repository.GetByIdAsync(request.Id, ct);

            if (response == null) {
                throw new ClothingItemNotFoundException(request.Id);
            }

            var category = await _repository.GetCategoryByIdAsync(response.CategoryId, ct);

            if (category == null) {
                throw new CategoryNotFoundException(response.CategoryId);
            }

            return response.ToGetResponse(category.Name);
        }
    }
}