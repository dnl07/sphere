using Sphere.Domain.Images.Exceptions;

namespace Sphere.Domain.MediaFiles {
    public partial class MediaFile {
        public MediaFile Create(string fileName, long fileSize, string contentType) {
            var mediaFile = new MediaFile(
                fileName,
                fileSize,
                contentType
            );

            Validate();

            return mediaFile;
        }
    }
}
