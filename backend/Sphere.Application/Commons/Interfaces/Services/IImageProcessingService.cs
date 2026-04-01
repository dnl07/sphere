using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sphere.Application.Commons.Interfaces.Services {
    public interface IImageProcessingService {
        byte[] TrimTransparentBackground(byte[] imageBytes);
    }
}
