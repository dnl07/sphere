using Sphere.Application.Commons.Interfaces;
using Sphere.Application.Commons.Interfaces.Repository;
using Sphere.Application.Commons.Exceptions;
using Microsoft.Extensions.Logging;
using Sphere.Application.Commons.Interfaces.Services;

namespace Sphere.Application.UseCases.ClothingItem.Commands.Delete {
    public class DeleteClothingItemHandler : IUseCaseHandler<DeleteClothingItemCommand, DeleteClothingItemResponse> {
        private readonly IClothingItemRepository _clothingRepository;
        private readonly IMediaFileRepository _mediaFileRepository;
        private readonly IFileStorage _fileStorage;

        private readonly ILogger<DeleteClothingItemHandler> _logger;
        
        public DeleteClothingItemHandler(
            IClothingItemRepository clothingRepository, 
            IMediaFileRepository mediaFileRepository, 
            IFileStorage fileStorage,
            ILogger<DeleteClothingItemHandler> logger) {
            _clothingRepository = clothingRepository;
            _mediaFileRepository = mediaFileRepository;
            _fileStorage = fileStorage;
            _logger = logger;
        }

        public async Task<DeleteClothingItemResponse> Handle(DeleteClothingItemCommand cmd, CancellationToken ct) {
            var item = await _clothingRepository.GetByIdAsync(cmd.Id, ct);

            if (item is null) {
                throw new ClothingItemNotFoundException(cmd.Id);
            }

            item.Delete();
            _logger.LogInformation("Deleting clothing item with id {Id}", cmd.Id);

            await _clothingRepository.DeleteAsync(cmd.Id, ct);
            await _mediaFileRepository.DeleteAsync(item.ImageId, ct);
            await _fileStorage.DeleteAsync(item.ImageId, ct);

            return new DeleteClothingItemResponse();
        }
    }
}
