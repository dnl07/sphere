namespace Sphere.Application.UseCases.MediaFiles.Queries.Get {
    public class GetMediaFileResponse {
        public byte[] FileData { get; set; }
        public string FileName { get; set; }
        public long FileSize { get; set; }
        public string ContentType { get; set; }

        public GetMediaFileResponse(byte[] fileData, string fileName, long fileSize, string contentType) {
            FileData = fileData;
            FileName = fileName;
            FileSize = fileSize;
            ContentType = contentType;
        }
    }
}
