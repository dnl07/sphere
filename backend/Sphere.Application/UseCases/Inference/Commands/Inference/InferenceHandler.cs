using Microsoft.Extensions.Logging;
using Sphere.Application.Commons.Interfaces;
using Sphere.Application.Commons.Interfaces.Services;

namespace Sphere.Application.UseCases.Inference.Commands.Inference {
    public class InferenceHandler : IUseCaseHandler<InferenceCommand, InferenceResponse> {
        private readonly IBackgroundRemoverService _backgroundRemover;
        private readonly ILogger<InferenceHandler> _logger;

        public InferenceHandler(IBackgroundRemoverService backgroundRemover, ILogger<InferenceHandler> logger) {
            _backgroundRemover = backgroundRemover;
            _logger = logger;
        }

        public async Task<InferenceResponse> Handle(InferenceCommand request, CancellationToken cancellationToken) {
            _logger.LogInformation("Performing inference on request image.");
            var imageData = await _backgroundRemover.RemoveBackgroundAsync(request.ImageData, cancellationToken);

            return new InferenceResponse {
                CroppedImageData = imageData
            };
        }
    }
}
