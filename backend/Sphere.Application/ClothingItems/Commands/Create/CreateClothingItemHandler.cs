using MediatR;
using Sphere.API.Mappers;

namespace Sphere.Application.ClothingItems.Commands.Create {
    public class CreateClothingItemHandler : IRequestHandler<CreateClothingItemCommand, CreateClothingItemResponse> {
        // private readonly IClothingRepository _repository;

        public CreateClothingItemHandler() { 
        
        }

        public async Task<CreateClothingItemResponse> Handle(CreateClothingItemCommand request, CancellationToken ct) {
            var item = request.ToDomain();

            // await _repository.AddSync(item);

            return item.ToResponse();
        }
    }
}
