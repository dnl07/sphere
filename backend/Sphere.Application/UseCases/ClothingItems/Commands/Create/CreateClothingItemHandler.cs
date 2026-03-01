using Sphere.API.Mappers;
using Sphere.Application.Commons.Interfaces;

namespace Sphere.Application.UseCases.ClothingItems.Commands.Create {
    public class CreateClothingItemHandler : IUseCaseHandler<CreateClothingItemCommand, CreateClothingItemResponse> {
        private readonly IClothingItemRepository _repository;

        public CreateClothingItemHandler(IClothingItemRepository repository) { 
            _repository = repository;
        }

        public async Task<CreateClothingItemResponse> Handle(CreateClothingItemCommand request, CancellationToken ct) {
            var item = request.ToDomain();

            await _repository.AddAsync(item, ct);

            return item.ToCreateResponse();
        }
    }
}
