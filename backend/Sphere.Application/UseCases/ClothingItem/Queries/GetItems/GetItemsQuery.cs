using Sphere.Application.Commons.Interfaces;
using Sphere.Application.UseCases.ClothingItem.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sphere.Application.UseCases.ClothingItem.Queries.GetItems {
    public class GetItemsQuery(ClothingItemFilter? filter = null) : IUseCase<GetItemsResponse> {
        public ClothingItemFilter? Filter { get; } = filter;
    }
}
