using Sphere.Application.Commons.Interfaces;
using Sphere.Application.UseCases.ClothingItems.Commons;

namespace Sphere.Application.UseCases.ClothingItems.Queries.GetCount {
    public class GetCountQuery(ClothingItemFilter? filter = null) : IUseCase<GetCountResponse> {
        public ClothingItemFilter? Filter { get; } = filter;
    }
}
