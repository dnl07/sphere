using Sphere.Application.Commons.Interfaces;
using Sphere.Application.Commons.Interfaces.Repository;

namespace Sphere.Application.UseCases.Image.Queries.Get {
    public class GetImageHandler : IUseCaseHandler<GetImageQuery, GetImageResponse> {
        private readonly IFileStorage _storage;
        private readonly IImageRepository _repository;

        public GetImageHandler(IFileStorage storage, IImageRepository repository) {
            _storage = storage;
            _repository = repository;
        }

        public async Task<GetImageResponse> Handle(GetImageQuery query, CancellationToken ct = default) {
            var bytes = await _storage.GetAsync(query.ImageId, ct);

            var metadata = await _repository.GetByIdAsync(query.ImageId, ct);

            if (metadata == null) {
                throw new Exception("Image metadata not found.");
            }

            return new GetImageResponse(
                bytes,
                metadata.FileName,
                metadata.FileSize,
                metadata.ContentType
            );
        }
    }
}