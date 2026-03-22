using Sphere.Application.UseCases.ClothingItem.Commons;
using Sphere.Domain.ClothingItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sphere.Infrastructure.Persistance.Specification {
    public class ClothingItemSpecification : Specification<ClothingItem> {
        private readonly ClothingItemFilter _filter;

        public ClothingItemSpecification(ClothingItemFilter filter) {
            _filter = filter;
        }

        public override IQueryable<ClothingItem> Apply(IQueryable<ClothingItem> query) {
            if (_filter.CategoryIds != null && _filter.CategoryIds.Length > 0) {
                query = query.Where(item => _filter.CategoryIds.Contains(item.CategoryId));
            }

            if (_filter.Colors != null && _filter.Colors.Length > 0) {
                query = query.Where(item => _filter.Colors.Contains(item.Color));
            }

            if (_filter.Materials != null && _filter.Materials.Length > 0) {
                query = query.Where(item => _filter.Materials.Contains(item.Material));
            }

            if (_filter.Sizes != null && _filter.Sizes.Length > 0) {
                query = query.Where(item => _filter.Sizes.Contains(item.Size));
            }

            if (_filter.FetchAll) {
                return query;
            }

            return query
                .Skip((_filter.PageNumber - 1) * _filter.PageSize)
                .Take(_filter.PageSize);
        }
    }
}
