using Sphere.Api.Dtos.Requests.ClothingItems;
using Sphere.Api.Utils;
using Sphere.Application.UseCases.ClothingItems.Commands.Create;
using Sphere.Application.UseCases.ClothingItems.Commands.Update;
using Sphere.Application.UseCases.ClothingItems.Commons;

namespace Sphere.API.Mappers {
    public static class ClothingItemMapper {
        public static CreateClothingItemCommand ToCreateCommand(this CreateClothingItemRequest request) {
            ArgumentNullException.ThrowIfNull(request);
            ArgumentNullException.ThrowIfNull(request.Image);

            return new CreateClothingItemCommand(
                name: request.Name,
                category: request.Category,
                size: request.Size,
                material: request.Material,
                color: request.Color,
                amount: request.PriceAmount ?? 0,
                currency: request.Currency ?? "EUR",
                boughtAt: request.BoughtAt,
                store: request.Store,
                brand: request.Brand,
                isArchived: request.IsArchived,
                notes: request.Notes,
                image: request.Image.ConvertToBytes(),
                imageFileName: request.Image.FileName,
                imageContentType: request.Image.ContentType
            );
        }

        public static UpdateClothingItemCommand ToUpdateCommand(this UpdateClothingItemRequest request, Guid Id) {
            ArgumentNullException.ThrowIfNull(request);

            var imageBytes = request.Image?.ConvertToBytes() ?? [];
            var imageFileName = request.Image?.FileName;
            var imageContentType = request.Image?.ContentType;

            return new UpdateClothingItemCommand(
                id: Id,
                name: request.Name,
                category: request.Category,
                size: request.Size,
                material: request.Material,
                color: request.Color,
                amount: request.PriceAmount,
                currency: request.Currency,
                boughtAt: request.BoughtAt,
                store: request.Store,
                brand: request.Brand,
                isArchived: request.IsArchived,
                notes: request.Notes,
                image: imageBytes,
                imageFileName: imageFileName,
                imageContentType: imageContentType
            );
        }

        public static ClothingItemFilter ToFilter(this ClothingItemFilterRequest request) {
            ArgumentNullException.ThrowIfNull(request);

            return new ClothingItemFilter {
                SearchQuery = request.SearchQuery,
                CategoryNames = request.CategoryNames,
                Colors = request.Colors,
                Sizes = request.Sizes,
                Materials = request.Materials,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                SortBy = request.SortBy
            };
        }
    }
}
