using Sphere.Application.UseCases.ClothingItems.Commons;
using Sphere.Domain.ClothingItems;

namespace Sphere.Infrastructure.Persistance.Specification {
    public class ClothingItemSpecification : Specification<ClothingItem> {
        private readonly ClothingItemFilter _filter;

        public ClothingItemSpecification(ClothingItemFilter filter) {
            _filter = filter;
        }

        public override IQueryable<ClothingItem> Apply(IQueryable<ClothingItem> query) {
            if (_filter.ItemIds != null && _filter.ItemIds.Length > 0) {
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

            return query;
        }

        public override IQueryable<ClothingItem> ApplyPagination(IQueryable<ClothingItem> query) {
            query = Apply(query);

            return query
                .Skip((_filter.PageNumber - 1) * _filter.PageSize)
                .Take(_filter.PageSize);
        }
    }
}
