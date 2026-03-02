using Sphere.API.Mappers;
using Sphere.Application.Commons.Interfaces;

namespace Sphere.Application.UseCases.ClothingItems.Commands.Create {
    public class CreateClothingItemHandler : IUseCaseHandler<CreateClothingItemCommand, CreateClothingItemResponse> {
        private readonly IClothingItemRepository _repository;

        private readonly IFileStorage _fileStorage;

        public CreateClothingItemHandler(IClothingItemRepository repository, IFileStorage fileStorage) { 
            _repository = repository;
            _fileStorage = fileStorage;
        }

        public async Task<CreateClothingItemResponse> Handle(CreateClothingItemCommand request, CancellationToken ct) {
            var item = request.ToDomain();

            await _repository.AddAsync(item, ct);

            var image = item.Image;
            await _fileStorage.SaveAsync(image.Id, request.Image, ct);

            return item.ToCreateResponse();
        }
    }
}
