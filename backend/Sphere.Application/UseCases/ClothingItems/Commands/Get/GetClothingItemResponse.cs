namespace Sphere.Application.UseCases.ClothingItems.Commands.Get {
    public class GetClothingItemResponse {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public GetClothingItemResponse(Guid id, string name, string type) {
            Id = id;
            Name = name;
            Type = type;
        }
    }
}
