namespace Sphere.Application.UseCases.ClothingItems.Queries.GetImage {
    public class GetClothingImageResponse {
        public byte[] FileData { get; set; }
        public string FileName { get; set; }
        public long FileSize { get; set; }
        public string ContentType { get; set; }

        public GetClothingImageResponse(byte[] fileData, string fileName, long fileSize, string contentType) {
            FileData = fileData;
            FileName = fileName;
            FileSize = fileSize;
            ContentType = contentType;
        }
    }
}
