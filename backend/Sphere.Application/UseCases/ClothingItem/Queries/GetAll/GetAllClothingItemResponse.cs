using Sphere.Application.UseCases.ClothingItems.Queries.Get;

namespace Sphere.Application.UseCases.ClothingItems.Queries.GetAll {
    public class GetAllClothingItemResponse {
        public List<GetClothingItemResponse> ClothingResponses { get; set; }

        public GetAllClothingItemResponse(List<GetClothingItemResponse> responses) {
            ClothingResponses = responses;
        }
    }
}
