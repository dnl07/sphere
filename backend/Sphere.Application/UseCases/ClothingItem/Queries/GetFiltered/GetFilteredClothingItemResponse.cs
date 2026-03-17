using Sphere.Application.Commons.Models;
using Sphere.Application.UseCases.ClothingItems.Queries.Get;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sphere.Application.UseCases.ClothingItem.Queries.GetFiltered {
    public class GetFilteredClothingItemResponse {
        public List<GetClothingItemResponse> Items { get; set; }
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }

        public GetFilteredClothingItemResponse(List<GetClothingItemResponse> items, int totalCount, int pageNumber, bool hasNextPage, bool hasPreviousPage) {
            Items = items;
            TotalCount = totalCount;
            PageNumber = pageNumber;
            HasNextPage = hasNextPage;
            HasPreviousPage = hasPreviousPage;
        }

        public static GetFilteredClothingItemResponse Empty() {
            return new GetFilteredClothingItemResponse([], 0, 1, false, false);
        }
    }
}
