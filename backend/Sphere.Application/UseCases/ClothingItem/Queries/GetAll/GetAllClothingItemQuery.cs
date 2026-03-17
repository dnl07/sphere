using Sphere.Application.Commons.Interfaces;

namespace Sphere.Application.UseCases.ClothingItems.Queries.GetAll {
    public class GetAllClothingItemQuery(ClothingItemFilter filter) : IUseCase<GetAllClothingItemResponse> {
        public ClothingItemFilter Filter { get; } = filter;
    }
}
