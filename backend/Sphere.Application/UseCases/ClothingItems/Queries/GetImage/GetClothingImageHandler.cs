using Sphere.Application.Commons.Exceptions;
using Sphere.Application.Commons.Interfaces;
using Sphere.Application.Commons.Interfaces.Repository;
using Sphere.Application.Commons.Interfaces.Services;

namespace Sphere.Application.UseCases.ClothingItems.Queries.GetImage {
    public class GetClothingImageHandler : IUseCaseHandler<GetClothingImageQuery, GetClothingImageResponse> {
        private readonly IClothingItemRepository _clothingRepository;
        private readonly IMediaFileRepository _mediaFileRepository;
        private readonly IFileStorage _storage;

        public GetClothingImageHandler(IClothingItemRepository clothingRepository, IMediaFileRepository mediaFileRepository, IFileStorage storage) {
            _clothingRepository = clothingRepository;
            _mediaFileRepository = mediaFileRepository;
            _storage = storage;
        }

        public async Task<GetClothingImageResponse> Handle(GetClothingImageQuery query, CancellationToken ct) {
            var item = await _clothingRepository.GetByIdAsync(query.ItemId, ct);

            if (item == null) {
                throw new ClothingItemNotFoundException(query.ItemId);
            }

            var imageData = await _mediaFileRepository.GetByIdAsync(item.ImageId);

            if (imageData == null) {
                throw new MediaFileNotFoundException(item.ImageId);
            }

            var image = await _storage.GetAsync(item.ImageId, ct);

            return new GetClothingImageResponse(image, imageData.FileName, imageData.FileSize, imageData.ContentType);
        }
    }
}