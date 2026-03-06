using Sphere.Application.Commons.Interfaces;

namespace Sphere.Application.UseCases.ClothingItem.Commands.Delete {
    public class DeleteClothingItemCommand : IUseCase<DeleteClothingItemResponse> {
        public Guid Id { get; set; }

        public DeleteClothingItemCommand(Guid id) {
            Id = id;
        }
    }
}
