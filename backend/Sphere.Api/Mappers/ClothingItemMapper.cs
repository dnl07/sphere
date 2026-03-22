using Sphere.Api.Dtos.Requests.ClothingItems;
using Sphere.Api.Utils;
using Sphere.Application.UseCases.ClothingItem.Commands.Update;
using Sphere.Application.UseCases.ClothingItem.Commons;
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
            var imageFileName = request.Image?.FileName;
            var imageContentType = request.Image?.ContentType;

            return new UpdateClothingItemCommand(
                id: Id,
                name: request.Name,
                category: request.Category,
                description: request.Description,
                size: request.Size,
                material: request.Material,
                color: request.Color,
                amount: request.PriceAmount,
                currency: request.Currency,
                image: imageBytes,
                imageFileName: imageFileName,
                imageContentType: imageContentType
            );
        }

        public static ClothingItemFilter ToFilter(this ClothingItemFilterRequest request) {
            ArgumentNullException.ThrowIfNull(request);

            return new ClothingItemFilter {
                CategoryIds = request.CategoryIds,
                Colors = request.Color,
                Sizes = request.Size,
                Materials = request.Material,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                FetchAll = request.FetchAll
            };
        }
    }
}
