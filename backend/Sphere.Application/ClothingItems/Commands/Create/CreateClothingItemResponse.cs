namespace Sphere.Application.ClothingItems.Commands.Create {
    public class CreateClothingItemResponse {
        public string Name { get; set; }
        public string Type { get; set; }

        public CreateClothingItemResponse(string name, string type) {
            Name = name;
            Type = type;
        }
    }
}
