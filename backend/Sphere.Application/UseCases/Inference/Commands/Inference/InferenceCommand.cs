using Sphere.Application.Commons.Interfaces;

namespace Sphere.Application.UseCases.Inference.Commands.Create {
    public class InferenceCommand : IUseCase<InferenceResponse> {
        public byte[] ImageData { get; set; } = [];

        public InferenceCommand(byte[] imageData) { 
            ImageData = imageData;
        }
    }
}
