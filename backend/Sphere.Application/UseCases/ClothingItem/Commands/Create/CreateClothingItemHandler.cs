using Sphere.Application.Commons.Exceptions;
using Sphere.Application.Commons.Interfaces;
using Sphere.Application.Commons.Interfaces.Repository;
using Sphere.Application.Mappers;
using Sphere.Domain.MediaFiles;

namespace Sphere.Application.UseCases.ClothingItems.Commands.Create {
    public class CreateClothingItemHandler : IUseCaseHandler<CreateClothingItemCommand, CreateClothingItemResponse> {
        private readonly IClothingItemRepository _clothingRepository;
        private readonly IMediaFileRepository _mediaFileRepository;

        private readonly IFileStorage _fileStorage;

        public CreateClothingItemHandler(IClothingItemRepository clothingRepository, IMediaFileRepository mediaFileRepository, IFileStorage fileStorage) { 
            _clothingRepository = clothingRepository;
            _fileStorage = fileStorage;
            _mediaFileRepository = mediaFileRepository;
        }

        public async Task<CreateClothingItemResponse> Handle(CreateClothingItemCommand cmd, CancellationToken ct) {
            var category = await _clothingRepository.GetCategoryByNameAsync(cmd.Category, ct);

            if (category is null) {
                throw new NotFoundException("Category not found.");
            }

            var mediaFile = MediaFile.Create(cmd.ImageFileName, cmd.Image.Length, cmd.ImageContentType);

            await _fileStorage.SaveAsync(mediaFile.Id, cmd.Image, ct);
            await _mediaFileRepository.AddAsync(mediaFile, ct);


            var item = cmd.ToDomain(category.Id, mediaFile.Id);

            await _clothingRepository.AddAsync(item, ct);

            return item.ToCreateResponse(category.Name);
        }
    }
}
