namespace Sphere.Application.UseCases.ClothingItems.Commands.Create {
    public class CreateClothingItemResponse {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public CreateClothingItemResponse(Guid id, string name, string type) {
            Id = id;
            Name = name;
            Type = type;
        }
    }
}
