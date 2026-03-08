using Sphere.API.Mappers;
using Sphere.Application.Commons.Exceptions;
using Sphere.Application.Commons.Interfaces;
using Sphere.Application.Commons.Interfaces.Repository;

namespace Sphere.Application.UseCases.ClothingItems.Queries.Get {
    public class GetClothingImageHandler : IUseCaseHandler<GetClothingImageQuery, GetClothingImageResponse> {
        private readonly IClothingItemRepository _repository;
        private readonly IFileStorage _storage;

        public GetClothingImageHandler(IClothingItemRepository repository, IFileStorage storage) {
            _repository = repository;
            _storage = storage;
        }

        public async Task<GetClothingImageResponse> Handle(GetClothingImageQuery request, CancellationToken ct) {
            var item = await _repository.GetByIdAsync(request.ItemId, ct);

            if (item == null) {
                throw new NotFoundException($"Clothing item with ID {request.ItemId} not found.");
            }

            var metadata = item.Image;

            var image = await _storage.GetAsync(metadata.Id, ct);

            return new GetClothingImageResponse(image, metadata.FileName, metadata.FileSize, metadata.ContentType);
        }
    }
}