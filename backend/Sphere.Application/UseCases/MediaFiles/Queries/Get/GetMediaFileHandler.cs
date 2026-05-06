using Microsoft.Extensions.Logging;
using Sphere.Application.Commons.Exceptions;
using Sphere.Application.Commons.Interfaces;
using Sphere.Application.Commons.Interfaces.Repository;
using Sphere.Application.Commons.Interfaces.Services;

namespace Sphere.Application.UseCases.MediaFiles.Queries.Get {
    public class GetMediaFileHandler : IUseCaseHandler<GetMediaFileQuery, GetMediaFileResponse> {
        private readonly IFileStorage _storage;
        private readonly IMediaFileRepository _repository;
        private readonly ILogger<GetMediaFileHandler> _logger;

        public GetMediaFileHandler(IFileStorage storage, IMediaFileRepository repository, ILogger<GetMediaFileHandler> logger) {
            _storage = storage;
            _repository = repository;
            _logger = logger;
        }

        public async Task<GetMediaFileResponse> Handle(GetMediaFileQuery query, CancellationToken ct = default) {
            _logger.LogInformation("Retrieving media file with ID {ImageId}", query.ImageId);

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