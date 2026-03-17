using Sphere.Application.Commons.Interfaces;
using Sphere.Application.UseCases.ClothingItems.Queries.GetAll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sphere.Application.UseCases.ClothingItem.Queries.GetFiltered {
    public class GetFilteredClothingItemQuery(ClothingItemFilter filter) : IUseCase<GetFilteredClothingItemResponse> {
        public ClothingItemFilter Filter { get; } = filter;
    }
}
