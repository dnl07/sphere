using Sphere.Application.UseCases.ClothingItems.Commons;
using Sphere.Domain.ClothingItems.ValueObjects;

namespace Sphere.Application.Mappers.ClothingItems {
    public static class PriceMapper {
        public static PriceDto ToDto(this Price price) {
            return new PriceDto(price.Amount, price.Currency);
        }
    }
}
