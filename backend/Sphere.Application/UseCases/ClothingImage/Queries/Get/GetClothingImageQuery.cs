using Sphere.Application.Commons.Interfaces;

namespace Sphere.Application.UseCases.ClothingImage.Queries.Get {
    public class GetClothingImageQuery : IUseCase<GetClothingImageResponse> {
        public Guid Id { get; set; }

        public GetClothingImageQuery(Guid id) {
            Id = id;
        }
    }
}
