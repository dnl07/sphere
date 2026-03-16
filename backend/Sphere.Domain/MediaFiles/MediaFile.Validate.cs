using Sphere.Domain.MediaFiles.Exceptions;

namespace Sphere.Domain.MediaFiles {
    public partial class MediaFile {
        private void Validate() {
            if (string.IsNullOrWhiteSpace(FileName)) {
                throw new InvalidMediaFileException("Filename is required");
            }

            if (string.IsNullOrWhiteSpace(FileName)) {
                throw new InvalidMediaFileException($"File size must be greater than 0, actual {FileSize}");
            }

            if (string.IsNullOrWhiteSpace(FileName)) {
                throw new InvalidMediaFileException("ContentType is required.");
            }
        }
    }
}
