using Sphere.Domain.Common;

namespace Sphere.Domain.ClothingImages {
    public class ClothingImage : Entity {
        public string FileName { get; set; }
        public long FileSize { get; set; }
        public string ContentType { get; set; }

        // For EF Core relationship
        public Guid ClothingItemId { get; set; }

        #pragma warning disable CS8618
        private ClothingImage() { }
        #pragma warning restore CS8618

        public ClothingImage(string fileName, long fileSize, string contentType) {
            FileName = fileName;
            FileSize = fileSize;
            ContentType = contentType;
        }
    }
}
