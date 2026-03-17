using Microsoft.Extensions.Logging;
using Sphere.Application.Commons.Exceptions;
using Sphere.Application.Commons.Interfaces;
using Sphere.Application.Commons.Interfaces.Repository;
using Sphere.Application.Commons.Interfaces.Services;
using Sphere.Application.Mappers.ClothingItems;
using Sphere.Application.UseCases.ClothingItems.Commands.Create;
using Sphere.Domain.MediaFiles;

namespace Sphere.Application.UseCases.ClothingItem.Commands.Create {
    public class CreateClothingItemHandler : IUseCaseHandler<CreateClothingItemCommand, CreateClothingItemResponse> {
        private readonly IClothingItemRepository _clothingRepository;
        private readonly IMediaFileRepository _mediaFileRepository;

        private readonly IFileStorage _fileStorage;

        private readonly ILogger<CreateClothingItemHandler> _logger;

        public CreateClothingItemHandler(
            IClothingItemRepository clothingRepository, 
            IMediaFileRepository mediaFileRepository, 
            IFileStorage fileStorage,
            ILogger<CreateClothingItemHandler> logger) { 
            _clothingRepository = clothingRepository;
            _fileStorage = fileStorage;
            _mediaFileRepository = mediaFileRepository;
            _logger = logger;
        }

        public async Task<CreateClothingItemResponse> Handle(CreateClothingItemCommand cmd, CancellationToken ct) {
            var category = await _clothingRepository.GetCategoryByNameAsync(cmd.Category, ct);

            _logger.LogInformation("Creating clothing item with name {Name} in category {Category} with id {id}", cmd.Name, cmd.Category, category?.Id);

            if (category is null) {
                throw new CategoryNotFoundException(cmd.Category);
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
