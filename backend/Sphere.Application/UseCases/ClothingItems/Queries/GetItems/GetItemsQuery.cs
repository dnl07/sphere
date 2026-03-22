using Sphere.Application.Commons.Interfaces;
using Sphere.Application.UseCases.ClothingItems.Commons;

namespace Sphere.Application.UseCases.ClothingItems.Queries.GetItems {
    public class GetItemsQuery(ClothingItemFilter? filter = null) : IUseCase<GetItemsResponse> {
        public ClothingItemFilter? Filter { get; } = filter;
    }
}
