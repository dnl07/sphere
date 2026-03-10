using Sphere.Application.Commons.Interfaces;
using Sphere.Application.Commons.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sphere.Application.UseCases.Inference.Commands.Create {
    public class CreateInferenceHandler : IUseCaseHandler<CreateInferenceCommand, CreateInferenceResponse> {
        private readonly IBackgroundRemoverService _backgroundRemover;

        public CreateInferenceHandler(IBackgroundRemoverService backgroundRemover) {
            _backgroundRemover = backgroundRemover;
        }

        public async Task<CreateInferenceResponse> Handle(CreateInferenceCommand request, CancellationToken cancellationToken) {
            var imageData = await _backgroundRemover.RemoveBackgroundAsync(request.ImageData, cancellationToken);

            return new CreateInferenceResponse {
                CroppedImageData = imageData
            };
        }
    }
}
