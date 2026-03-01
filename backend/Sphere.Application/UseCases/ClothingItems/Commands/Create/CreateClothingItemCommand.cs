using MediatR;
using Sphere.Application.Commons.Interfaces;

namespace Sphere.Application.UseCases.ClothingItems.Commands.Create {
    public class CreateClothingItemCommand : IUseCase<CreateClothingItemResponse> {
        public string Name { get; set; }
        public string Type { get; set; }

        public CreateClothingItemCommand(string name, string type) {
            Name = name;
            Type = type;
        }
    }
}
