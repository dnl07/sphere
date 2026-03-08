using Sphere.Application.Commons.Interfaces;

namespace Sphere.Application.UseCases.Image.Queries.Get {
    public class GetImageQuery : IUseCase<GetImageResponse> {
        public Guid ImageId { get; set; }

        public GetImageQuery(Guid imageId) { 
            ImageId = imageId;
        }
    }
}
