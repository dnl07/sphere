using Sphere.Application.Commons.Interfaces;
using Sphere.Application.Commons.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sphere.Application.UseCases.ClothingItem.Queries.GetMeta {
    public class GetMetaClothingItemHandler : IUseCaseHandler<GetMetaClothingItemQuery, GetMetaClothingItemResponse> {
        private IClothingItemRepository _repository;

        public GetMetaClothingItemHandler(IClothingItemRepository repository) {
            _repository = repository;
        }

        public async Task<GetMetaClothingItemResponse> Handle(GetMetaClothingItemQuery query, CancellationToken ct) {
            var meta = await _repository.GetMetaAsync(ct);

            return new GetMetaClothingItemResponse(
                TotalItems: meta.TotalItems,
                AvailableColors: meta.AvailableColors,
                AvailableSizes: meta.AvailableSizes,
                AvailableMaterials: meta.AvailableMaterials,
                AvailableCategories: meta.AvailableCategories,
                MinPrice: meta.MinPrice,
                MaxPrice: meta.MaxPrice
            );
        }
    }
}
