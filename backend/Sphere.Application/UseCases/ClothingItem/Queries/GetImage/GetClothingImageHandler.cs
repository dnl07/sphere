using Sphere.Application.Commons.Exceptions;
using Sphere.Application.Commons.Interfaces;
using Sphere.Application.Commons.Interfaces.Repository;

namespace Sphere.Application.UseCases.ClothingItems.Queries.Get {
    public class GetClothingImageHandler : IUseCaseHandler<GetClothingImageQuery, GetClothingImageResponse> {
        private readonly IClothingItemRepository _clothingRepository;
        private readonly IMediaFileRepository _mediaFileRepository;
        private readonly IFileStorage _storage;

        public GetClothingImageHandler(IClothingItemRepository clothingRepository, IMediaFileRepository mediaFileRepository, IFileStorage storage) {
            _clothingRepository = clothingRepository;
            _mediaFileRepository = mediaFileRepository;
            _storage = storage;
        }

        public async Task<GetClothingImageResponse> Handle(GetClothingImageQuery request, CancellationToken ct) {
            var item = await _clothingRepository.GetByIdAsync(request.ItemId, ct);

            if (item == null) {
                throw new NotFoundException($"Clothing item with ID {request.ItemId} not found.");
            }

            var imageData = await _mediaFileRepository.GetByIdAsync(item.ImageId);

            if (imageData == null) {
                throw new NotFoundException($"Image with ID {item.ImageId} not found.");
            }

            var image = await _storage.GetAsync(item.ImageId, ct);

            return new GetClothingImageResponse(image, imageData.FileName, imageData.FileSize, imageData.ContentType);
        }
    }
}