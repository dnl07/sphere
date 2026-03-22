using Sphere.Application.Commons.Interfaces;
using Sphere.Application.UseCases.ClothingItems.Commons;

namespace Sphere.Application.UseCases.ClothingItems.Queries.GetById {
    public class GetClothingItemByIdQuery(Guid id) : IUseCase<ClothingItemDto> {
        public Guid Id { get; set; } = id;
    }
}