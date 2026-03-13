using Sphere.Api.Utils;
using Sphere.API.Dtos.Requests;
using Sphere.Application.UseCases.ClothingItem.Commands.Update;
using Sphere.Application.UseCases.ClothingItems.Commands.Create;

namespace Sphere.API.Mappers {
    public static class ClothingItemMapper {
        public static CreateClothingItemCommand ToCreateCommand(this CreateClothingItemRequestDto request) {
            ArgumentNullException.ThrowIfNull(request);
            ArgumentNullException.ThrowIfNull(request.Image);

            return new CreateClothingItemCommand(
                name: request.Name,
                category: request.Category,
                description: request.Description ?? string.Empty,
                size: request.Size ?? string.Empty,
                material: request.Material ?? string.Empty,
                color: request.Color ?? string.Empty,
                amount: request.PriceAmount ?? 0,
                currency: request.Currency ?? "EUR",
                image: request.Image.ConvertToBytes(),
                imageFileName: request.Image.FileName,
                imageContentType: request.Image.ContentType
            );
        }

        public static UpdateClothingItemCommand ToUpdateCommand(this UpdateClothingItemRequestDto request, Guid Id) {
            ArgumentNullException.ThrowIfNull(request);

            var imageBytes = request.Image?.ConvertToBytes() ?? [];
            var imageFileName = request.Image?.FileName ?? string.Empty;
            var imageContentType = request.Image?.ContentType ?? string.Empty;

            return new UpdateClothingItemCommand(
                id: Id,
                name: request.Name,
                category: request.Category,
                description: request.Description ?? string.Empty,
                size: request.Size ?? string.Empty,
                material: request.Material ?? string.Empty,
                color: request.Color ?? string.Empty,
                amount: request.PriceAmount ?? 0,
                currency: request.Currency ?? "EUR",
                image: imageBytes,
                imageFileName: imageFileName,
                imageContentType: imageContentType
            );
        }
    }
}
