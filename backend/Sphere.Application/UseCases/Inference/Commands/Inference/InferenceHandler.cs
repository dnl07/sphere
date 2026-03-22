using Sphere.Application.Commons.Interfaces;
using Sphere.Application.Commons.Interfaces.Services;

namespace Sphere.Application.UseCases.Inference.Commands.Create {
    public class InferenceHandler : IUseCaseHandler<InferenceCommand, InferenceResponse> {
        private readonly IBackgroundRemoverService _backgroundRemover;

        public InferenceHandler(IBackgroundRemoverService backgroundRemover) {
            _backgroundRemover = backgroundRemover;
        }

        public async Task<InferenceResponse> Handle(InferenceCommand request, CancellationToken cancellationToken) {
            var imageData = await _backgroundRemover.RemoveBackgroundAsync(request.ImageData, cancellationToken);

            return new InferenceResponse {
                CroppedImageData = imageData
            };
        }
    }
}
