using Sphere.Application.Commons.Interfaces;

namespace Sphere.Application.UseCases.ClothingItems.Queries.Get {
    public class GetClothingItemQuery(Guid id) : IUseCase<GetClothingItemResponse> {
        public Guid Id { get; set; } = id;
    }
}