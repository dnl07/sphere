using MediatR;

namespace Sphere.Application.ClothingItems.Commands.Create {
    public class CreateClothingItemCommand : IRequest<CreateClothingItemResponse> {
        public string Name { get; set; }
        public string Type { get; set; }

        public CreateClothingItemCommand(string name, string type) {
            Name = name;
            Type = type;
        }
    }
}
