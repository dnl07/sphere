using Sphere.Application.Commons.Exceptions;
using Sphere.Application.Commons.Interfaces;

namespace Sphere.Application.UseCases.ClothingImage.Queries.Get {
    public class GetClothingImageHandler : IUseCaseHandler<GetClothingImageQuery, GetClothingImageResponse> {
        private readonly IFileStorage _fileStorage;
        private readonly IClothingItemRepository _repository;

        public GetClothingImageHandler(IFileStorage fileStorage, IClothingItemRepository repository) {
            _fileStorage = fileStorage;
            _repository = repository;
        }

        public async Task<GetClothingImageResponse> Handle(GetClothingImageQuery request, CancellationToken ct) {
            var item = await _repository.GetByIdAsync(request.Id, ct);

            if (item == null) {
                throw new NotFoundException($"Clothing item with ID {request.Id} not found.");
            }

            var imageId = item.Image.Id;

            byte[] image = await _fileStorage.GetAsync(imageId, ct);

            if (image == null || image.Length == 0) {
                throw new NotFoundException($"Clothing item with ID {request.Id} not found.");
            }

            return new GetClothingImageResponse(request.Id, image, item.Image.FileName, item.Image.ContentType);
        }
    }
}