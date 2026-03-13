using Sphere.Domain.Common;

namespace Sphere.Domain.MediaFiles {
    public partial class MediaFile : Entity {
        public string FileName { get; private set; }
        public long FileSize { get; private set; }
        public string ContentType { get; private set; }

        #pragma warning disable CS8618
        private MediaFile() { }
        #pragma warning restore CS8618

        private MediaFile(string fileName, long fileSize, string contentType) {
            FileName = fileName;
            FileSize = fileSize;
            ContentType = contentType;
        }
    }
}
