using Sphere.API.Mappers;
using Sphere.Application.Commons.Exceptions;
using Sphere.Application.Commons.Interfaces;

namespace Sphere.Application.UseCases.ClothingItems.Commands.Get {
    public class GetClothingItemHandler : IUseCaseHandler<GetClothingItemQuery, GetClothingItemResponse> {
        private readonly IClothingItemRepository _repository;

        public GetClothingItemHandler(IClothingItemRepository repository) {
            _repository = repository;
        }

        public async Task<GetClothingItemResponse> Handle(GetClothingItemQuery request, CancellationToken ct) {
            var response = await _repository.GetByIdAsync(request.Id, ct);

            if (response == null) {
                throw new NotFoundException($"Clothing item with ID {request.Id} not found.");
            }

            return response.ToGetResponse();
        }
    }
}