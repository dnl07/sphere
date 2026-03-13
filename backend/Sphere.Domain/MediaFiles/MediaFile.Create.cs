namespace Sphere.Domain.MediaFiles {
    public partial class MediaFile {
        public static MediaFile Create(string fileName, long fileSize, string contentType) {
            var mediaFile = new MediaFile(
                fileName,
                fileSize,
                contentType
            );

            mediaFile.Validate();

            return mediaFile;
        }
    }
}
