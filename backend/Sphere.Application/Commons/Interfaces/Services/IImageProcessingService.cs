namespace Sphere.Application.Commons.Interfaces.Services {
    public interface IImageProcessingService {
        byte[] TrimTransparentBackground(byte[] imageBytes);
    }
}
