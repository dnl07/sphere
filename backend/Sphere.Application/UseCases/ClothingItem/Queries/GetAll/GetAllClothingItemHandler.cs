using Sphere.API.Mappers;
using Sphere.Application.Commons.Exceptions;
using Sphere.Application.Commons.Interfaces;
using Sphere.Application.Commons.Interfaces.Repository;

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

            return new GetAllClothingItemResponse(items.Select(i => i.ToGetResponse()).ToList());
        }
    }
}