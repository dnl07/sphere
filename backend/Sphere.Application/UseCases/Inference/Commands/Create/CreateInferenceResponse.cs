using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sphere.Application.UseCases.Inference.Commands.Create {
    public class CreateInferenceResponse {
        public byte[] CroppedImageData { get; set; } = [];
    }
}
