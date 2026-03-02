using Sphere.Api.Utils;
using Sphere.API.Dtos.Requests;
using Sphere.Application.UseCases.ClothingItems.Commands.Create;

namespace Sphere.API.Mappers {
    public static class ClothingItemMapper {
        public static CreateClothingItemCommand ToCommand(this CreateClothingItemRequestDto request) {
            byte[] image = request.Image != null ? request.Image.ConvertToBytes() : [];
            string imageFileName = request.Image != null ? request.Image.FileName : string.Empty;
            string imageContentType = request.Image != null ? request.Image.ContentType : string.Empty;

            return new CreateClothingItemCommand(
                request.Name,
                request.Category,
                request.Description,
                request.Size,
                request.Material,
                request.Color,
                request.PriceAmount,
                request.Currency,
                image,
                imageFileName,
                imageContentType
            );
        }
    }
}
