using Sphere.Application.Commons.Exceptions;
using Sphere.Application.Commons.Interfaces;
using Sphere.Application.Commons.Interfaces.Repository;
using Sphere.Application.Mappers;
using Sphere.Domain.MediaFiles;
using Microsoft.Extensions.Logging;

namespace Sphere.Application.UseCases.ClothingItem.Commands.Update {
    public class UpdateClothingItemHandler : IUseCaseHandler<UpdateClothingItemCommand, UpdateClothingItemResponse> {
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

        public async Task<UpdateClothingItemResponse> Handle(UpdateClothingItemCommand cmd, CancellationToken ct) {
            var item = await _clothingRepository.GetByIdAsync(cmd.Id, ct)
                ?? throw new NotFoundException($"Clothing item with ID {cmd.Id} not found.");

            Guid? categoryId = null;
            if (cmd.Category != null) {
                _logger.LogInformation("Looking up category '{CategoryName}' for clothing item update.", cmd.Category);

                var category = await _clothingRepository.GetCategoryByNameAsync(cmd.Category, ct)
                    ?? throw new NotFoundException($"Category '{cmd.Category}' not found.");
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
                name: cmd.Name,
                categoryId: categoryId,
                description: cmd.Description,
                size: cmd.Size,
                material: cmd.Material,
                color: cmd.Color,
                priceAmount: cmd.PriceAmount,
                currency: cmd.Currency,
                imageId: newImageId ?? item.ImageId
            );

            await _clothingRepository.SaveChangesAsync(ct);

            if (oldImageId is not null) {
                await _fileStorage.DeleteAsync(oldImageId.Value, ct);
            }

            var updatedCategory = await _clothingRepository.GetCategoryByIdAsync(item.CategoryId, ct);

            _logger.LogInformation("Category {name} with id {id} searched with id {iid}", updatedCategory?.Name, updatedCategory?.Id, item.CategoryId);

            if (updatedCategory is null) {
                _logger.LogWarning("Category with ID '{CategoryId}' not found after clothing item update.", item.CategoryId);
                throw new NotFoundException($"Category with ID '{item.CategoryId}' not found after update.");
            }

            return item.ToUpdateResponse(updatedCategory.Name);
        }
    }
}
