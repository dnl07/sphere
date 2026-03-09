using Sphere.Application.Commons.Interfaces;
using Sphere.Application.Commons.Interfaces.Repository;

namespace Sphere.Application.UseCases.ClothingItem.Commands.Delete {
    public class DeleteClothingItemHandler : IUseCaseHandler<DeleteClothingItemCommand, DeleteClothingItemResponse> {
        private readonly IClothingItemRepository _repository;

        public DeleteClothingItemHandler(IClothingItemRepository repository) {
            _repository = repository;
        }

        public async Task<DeleteClothingItemResponse> Handle(DeleteClothingItemCommand cmd, CancellationToken ct) {
            var item = await _repository.GetByIdAsync(cmd.Id, ct);

            if (item != null) {
                item.Delete();
            }

            await _repository.DeleteAsync(cmd.Id, ct);

            return new DeleteClothingItemResponse();
        }
    }
}
