using Sphere.Application.UseCases.ClothingItem.Commons;
using Sphere.Domain.ClothingItems.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sphere.Application.Mappers.ClothingItems {
    public static class PriceMapper {
        public static PriceDto ToDto(this Price price) {
            return new PriceDto(price.Amount, price.Currency);
        }
    }
}
