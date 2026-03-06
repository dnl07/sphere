using Sphere.Application.Commons.Interfaces;
using Sphere.Application.Commons.Interfaces.Repository;

namespace Sphere.Application.UseCases.ClothingItem.Commands.Delete {
    public class DeleteClothingItemHandler : IUseCaseHandler<DeleteClothingItemCommand, DeleteClothingItemResponse> {
        private IFileStorage _fileStorage;
        private IClothingItemRepository _repository;

        public DeleteClothingItemHandler(IFileStorage fileStorage, IClothingItemRepository repository) {
            _fileStorage = fileStorage;
            _repository = repository;
        }

        public async Task<DeleteClothingItemResponse> Handle(DeleteClothingItemCommand cmd, CancellationToken ct) {
            await _fileStorage.DeleteAsync(cmd.Id, ct);
            await _repository.DeleteAsync(cmd.Id, ct);

            return new DeleteClothingItemResponse();
        }
    }
}
