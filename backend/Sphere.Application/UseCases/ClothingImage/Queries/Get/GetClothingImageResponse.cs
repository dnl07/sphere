namespace Sphere.Application.UseCases.ClothingImage.Queries.Get {
    public class GetClothingImageResponse {
        public Guid Id { get; set; }
        public byte[] Image { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; } 

        public GetClothingImageResponse(Guid id, byte[] image, string fileName, string contentType) {
            Id = id;
            Image = image;
            FileName = fileName;
            ContentType = contentType;
        }
    }
}
