using Sphere.Application.Commons.Interfaces;

namespace Sphere.Application.UseCases.ClothingItems.Queries.Get {
    public class GetClothingItemQuery : IUseCase<GetClothingItemResponse> {
        public Guid Id { get; set; }

        public GetClothingItemQuery(Guid id) {
            Id = id;
        }
    }
}
