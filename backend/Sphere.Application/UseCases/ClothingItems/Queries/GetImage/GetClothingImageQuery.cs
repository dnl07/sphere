using Sphere.Application.Commons.Interfaces;

namespace Sphere.Application.UseCases.ClothingItems.Queries.GetImage {
    public class GetClothingImageQuery : IUseCase<GetClothingImageResponse> {
        public Guid ItemId { get; set; }

        public GetClothingImageQuery(Guid itemId) {
            ItemId = itemId;
        }
    }
}
