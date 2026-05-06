using Microsoft.Extensions.Logging;
using Sphere.Application.Commons.Exceptions;
using Sphere.Application.Commons.Interfaces;
using Sphere.Application.Commons.Interfaces.Repository;
using Sphere.Application.Commons.Interfaces.Services;
using Sphere.Application.Mappers.ClothingItems;
using Sphere.Application.UseCases.ClothingItems.Commons;
using Sphere.Domain.MediaFiles;

namespace Sphere.Application.UseCases.ClothingItems.Commands.Update {
    public class UpdateClothingItemHandler : IUseCaseHandler<UpdateClothingItemCommand, ClothingItemDto> {
        private readonly IClothingItemRepository _clothingRepository;
        private readonly IMediaFileRepository _mediaFileRepository;

        private readonly IFileStorage _fileStorage;

        private readonly ILogger<UpdateClothingItemHandler> _logger;

        public UpdateClothingItemHandler(
            IClothingItemRepository clothingRepository, 
            IMediaFileRepository mediaFileRepository, 
            IFileStorage fileStorage,
            ILogger<UpdateClothingItemHandler> logger) {
            _clothingRepository = clothingRepository;
            _fileStorage = fileStorage;
            _mediaFileRepository = mediaFileRepository;

            _logger = logger;
        }

        public async Task<ClothingItemDto> Handle(UpdateClothingItemCommand cmd, CancellationToken ct) {
            _logger.LogInformation("Updating clothing item with ID {Id}", cmd.Id);

            var item = await _clothingRepository.GetByIdAsync(cmd.Id, ct)
                ?? throw new ClothingItemNotFoundException(cmd.Id);

            Guid? categoryId = null;
            if (cmd.Category != null) {
                var category = await _clothingRepository.GetCategoryByNameAsync(cmd.Category, ct)
                    ?? throw new CategoryNotFoundException(cmd.Category);
                categoryId = category.Id;
            }

            Guid? newImageId = null;
            Guid? oldImageId = null;

            if (cmd.Image?.Length > 0 && cmd.ImageFileName is not null && cmd.ImageContentType is not null) {
                var mediaFile = MediaFile.Create(cmd.ImageFileName, cmd.Image.Length, cmd.ImageContentType);
                await _fileStorage.SaveAsync(mediaFile.Id, cmd.Image, ct);
                await _mediaFileRepository.AddAsync(mediaFile, ct);

                oldImageId = item.ImageId;
                newImageId = mediaFile.Id;
            }

            item.Update(
                categoryId: categoryId,
                size: cmd.Size,
                material: cmd.Material,
                color: cmd.Color,
                priceAmount: cmd.PriceAmount,
                currency: cmd.Currency,
                boughtAt: cmd.BoughtAt,
                store: cmd.Store,
                brand: cmd.Brand,
                isArchived: cmd.IsArchived,
                notes: cmd.Notes,
                imageId: newImageId ?? item.ImageId
            );

            await _clothingRepository.SaveChangesAsync(ct);

            if (oldImageId is not null) {
                await _fileStorage.DeleteAsync(oldImageId.Value, ct);
            }

            var updatedCategory = await _clothingRepository.GetCategoryByIdAsync(item.CategoryId, ct);

            if (updatedCategory is null) {
                _logger.LogWarning("Category with ID '{CategoryId}' not found", item.CategoryId);
                throw new CategoryNotFoundException(item.CategoryId);
            }

            return item.ToDto(updatedCategory.Name);
        }
    }
}
