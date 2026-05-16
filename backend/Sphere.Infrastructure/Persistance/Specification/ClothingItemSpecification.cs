using Microsoft.Extensions.Logging;
using Sphere.Application.UseCases.ClothingItems.Commons;
using Sphere.Domain.ClothingItems;

namespace Sphere.Infrastructure.Persistance.Specification {
    public class ClothingItemSpecification : Specification<ClothingItem> {
        private readonly ClothingItemFilter _filter;
        private readonly ILogger _logger;
        public ClothingItemSpecification(ClothingItemFilter filter, ILogger logger) {
            _filter = filter;
            _logger = logger;
        }

        public override IQueryable<ClothingItem> Apply(IQueryable<ClothingItem> query) {
            if (_filter.ItemIds != null) {
                query = query.Where(item => _filter.ItemIds.Contains(item.Id));
            }

            if (_filter.CategoryIds != null && _filter.CategoryIds.Length > 0) {
                query = query.Where(item => _filter.CategoryIds.Contains(item.CategoryId));
            }

            if (_filter.Colors != null && _filter.Colors.Length > 0) {
                var colorsLower = _filter.Colors.Select(c => c.ToLower()).ToArray();
                query = query.Where(item => colorsLower.Contains(item.Color!.ToLower()));
            }

            if (_filter.Materials != null && _filter.Materials.Length > 0) {
                var materialsLower = _filter.Materials.Select(m => m.ToLower()).ToArray();
                query = query.Where(item => materialsLower.Contains(item.Material!.ToLower()));
            }

            if (_filter.Sizes != null && _filter.Sizes.Length > 0) {
                var sizesLower = _filter.Sizes.Select(s => s.ToLower()).ToArray();
                query = query.Where(item => sizesLower.Contains(item.Size!.ToLower()));
            }

            if (_filter.Brands != null && _filter.Brands.Length > 0) {
                var brandsLower = _filter.Brands.Select(b => b.ToLower()).ToArray();
                query = query.Where(item => brandsLower.Contains(item.Brand!.ToLower()));
            }

            if (_filter.Stores != null && _filter.Stores.Length > 0) {
                var storesLower = _filter.Stores.Select(s => s.ToLower()).ToArray();
                query = query.Where(item => storesLower.Contains(item.Store!.ToLower()));
            }

            if (_filter.PriceMin != null) {
                query = query.Where(item => item.Price! >= _filter.PriceMin);
            }

            if (_filter.PriceMax != null) {
                query = query.Where(item => item.Price! <= _filter.PriceMax);
            }

            query = _filter.SortBy switch {
                ClothingItemSortOrder.PriceAsc => query.OrderBy(item => item.Price!),
                ClothingItemSortOrder.PriceDesc => query.OrderByDescending(item => item.Price!),
                ClothingItemSortOrder.Oldest => query.OrderBy(item => item.CreatedAt),
                _ => query.OrderByDescending(item => item.CreatedAt)
            };

            return query;
        }

        public override IQueryable<ClothingItem> ApplyPagination(IQueryable<ClothingItem> query) {
            query = Apply(query);

            query = query
                .Skip((_filter.PageNumber - 1) * _filter.PageSize)
                .Take(_filter.PageSize);

            return query;
        }
    }
}
