using Sphere.Application.Commons.Interfaces;

namespace Sphere.Application.UseCases.MediaFiles.Queries.Get {
    public class GetMediaFileQuery : IUseCase<GetMediaFileResponse> {
        public Guid ImageId { get; set; }

        public GetMediaFileQuery(Guid imageId) { 
            ImageId = imageId;
        }
    }
}
