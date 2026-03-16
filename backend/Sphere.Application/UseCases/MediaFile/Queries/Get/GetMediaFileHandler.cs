using Sphere.Application.Commons.Exceptions;
using Sphere.Application.Commons.Interfaces;
using Sphere.Application.Commons.Interfaces.Repository;
using Sphere.Application.Commons.Interfaces.Services;

namespace Sphere.Application.UseCases.Image.Queries.Get {
    public class GetMediaFileHandler : IUseCaseHandler<GetMediaFileQuery, GetMediaFileResponse> {
        private readonly IFileStorage _storage;
        private readonly IMediaFileRepository _repository;

        public GetMediaFileHandler(IFileStorage storage, IMediaFileRepository repository) {
            _storage = storage;
            _repository = repository;
        }

        public async Task<GetMediaFileResponse> Handle(GetMediaFileQuery query, CancellationToken ct = default) {
            var bytes = await _storage.GetAsync(query.ImageId, ct);

            var metadata = await _repository.GetByIdAsync(query.ImageId, ct);

            if (metadata == null) {
                throw new MediaFileNotFoundException(query.ImageId);
            }

            return new GetMediaFileResponse(
                bytes,
                metadata.FileName,
                metadata.FileSize,
                metadata.ContentType
            );
        }
    }
}