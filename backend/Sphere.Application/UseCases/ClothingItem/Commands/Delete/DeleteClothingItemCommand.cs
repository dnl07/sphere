using Sphere.Application.Commons.Interfaces;

namespace Sphere.Application.UseCases.ClothingItem.Commands.Delete {
    public class DeleteClothingItemCommand(Guid id) : IUseCase<DeleteClothingItemResponse> {
        public Guid Id { get; set; } = id;
    }
}