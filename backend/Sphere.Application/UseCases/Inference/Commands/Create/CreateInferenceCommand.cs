using Sphere.Application.Commons.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sphere.Application.UseCases.Inference.Commands.Create {
    public class CreateInferenceCommand : IUseCase<CreateInferenceResponse> {
        public byte[] ImageData { get; set; } = [];

        public CreateInferenceCommand(byte[] imageData) { 
            ImageData = imageData;
        }
    }
}
