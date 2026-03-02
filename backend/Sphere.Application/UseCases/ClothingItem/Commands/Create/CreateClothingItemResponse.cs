namespace Sphere.Application.UseCases.ClothingItems.Commands.Create {
    public class CreateClothingItemResponse {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public CreateClothingItemResponse(Guid id, string name) {
            Id = id;
            Name = name;
        }
    }
}
