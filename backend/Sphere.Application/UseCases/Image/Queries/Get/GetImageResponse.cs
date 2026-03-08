namespace Sphere.Application.UseCases.Image.Queries.Get {
    public class GetImageResponse {
        public byte[] FileData { get; set; }
        public string FileName { get; set; }
        public long FileSize { get; set; }
        public string ContentType { get; set; }

        public GetImageResponse(byte[] fileData, string fileName, long fileSize, string contentType) {
            FileData = fileData;
            FileName = fileName;
            FileSize = fileSize;
            ContentType = contentType;
        }
    }
}
