using Sphere.Application.Commons.Interfaces;

namespace Sphere.Application.UseCases.Inference.Commands.Create {
    public class CreateInferenceCommand : IUseCase<CreateInferenceResponse> {
        public byte[] ImageData { get; set; } = [];

        public CreateInferenceCommand(byte[] imageData) { 
            ImageData = imageData;
        }
    }
}
