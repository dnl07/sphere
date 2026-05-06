using Microsoft.Extensions.Logging;
using Sphere.Application.Commons.Exceptions;
using Sphere.Application.Commons.Interfaces;
using Sphere.Application.Commons.Interfaces.Repository;
using Sphere.Application.Commons.Interfaces.Services;

namespace Sphere.Application.UseCases.ClothingItems.Queries.GetImage {
    public class GetClothingImageHandler : IUseCaseHandler<GetClothingImageQuery, GetClothingImageResponse> {
        private readonly IClothingItemRepository _clothingRepository;
        private readonly IMediaFileRepository _mediaFileRepository;
        private readonly IFileStorage _storage;
        private readonly ILogger<GetClothingImageHandler> _logger;

        public GetClothingImageHandler(IClothingItemRepository clothingRepository, IMediaFileRepository mediaFileRepository, IFileStorage storage, ILogger<GetClothingImageHandler> logger) {
            _clothingRepository = clothingRepository;
            _mediaFileRepository = mediaFileRepository;
            _storage = storage;
            _logger = logger;
        }

        public async Task<GetClothingImageResponse> Handle(GetClothingImageQuery query, CancellationToken ct) {
            _logger.LogInformation("Retrieving image for clothing item with ID {ItemId}", query.ItemId);

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