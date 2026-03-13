using Sphere.Application.Commons.Interfaces;
using Sphere.Application.Commons.Interfaces.Repository;
using Sphere.Domain.MediaFiles;

namespace Sphere.Application.UseCases.ClothingItem.Commands.Update {
    public class UpdateClothingItemHandler : IUseCaseHandler<UpdateClothingItemCommand, UpdateClothingItemResponse> {
        private readonly IClothingItemRepository _clothingRepository;
        private readonly IMediaFileRepository _mediaFileRepository;

        private readonly IFileStorage _fileStorage;

        public UpdateClothingItemHandler(IClothingItemRepository clothingRepository, IMediaFileRepository mediaFileRepository, IFileStorage fileStorage) {
            _clothingRepository = clothingRepository;
            _fileStorage = fileStorage;
            _mediaFileRepository = mediaFileRepository;
        }

        public async Task<UpdateClothingItemResponse> Handle(UpdateClothingItemCommand cmd, CancellationToken ct) {
            Guid? categoryId = null;
            if (cmd.Category is not null) {
                var category = await _clothingRepository.GetCategoryByNameAsync(cmd.Category, ct);
                categoryId = category?.Id;
            }

            var item = await _clothingRepository.GetByIdAsync(cmd.Id, ct);

            if (item == null) {
                throw new Exception();
            }

            Guid? imageId = null;
            if (cmd.Image is not null && cmd.Image.Length > 0 && cmd.ImageFileName is not null && cmd.ImageContentType is not null) {
                var mediaFile = MediaFile.Create(cmd.ImageFileName, cmd.Image.Length, cmd.ImageContentType);
                await _fileStorage.SaveAsync(mediaFile.Id, cmd.Image, ct);

                await _fileStorage.DeleteAsync(item.ImageId, ct);

                await _mediaFileRepository.AddAsync(mediaFile, ct);
                imageId = mediaFile.Id;
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
                imageId: imageId
            );

            await _clothingRepository.SaveChangesAsync(ct);

            return new UpdateClothingItemResponse();
        }
    }
}
