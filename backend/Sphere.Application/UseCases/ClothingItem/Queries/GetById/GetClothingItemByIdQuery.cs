using Sphere.Application.Commons.Interfaces;
using Sphere.Application.UseCases.ClothingItem.Commons;

namespace Sphere.Application.UseCases.ClothingItems.Queries.Get {
    public class GetClothingItemByIdQuery(Guid id) : IUseCase<ClothingItemDto> {
        public Guid Id { get; set; } = id;
    }
}