using Sphere.Domain.Common;

namespace Sphere.Domain.Images {
    public class Image : Entity {
        public string FileName { get; set; }
        public long FileSize { get; set; }
        public string ContentType { get; set; }

        #pragma warning disable CS8618
        private Image() { }
        #pragma warning restore CS8618

        public Image(string fileName, long fileSize, string contentType) {
            FileName = fileName;
            FileSize = fileSize;
            ContentType = contentType;
        }
    }
}
