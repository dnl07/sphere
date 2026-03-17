using Sphere.Application.UseCases.ClothingItem.Queries.GetFiltered;
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

            if (_filter.Color != null && _filter.Color.Length > 0) {
                query = query.Where(item => _filter.Color.Contains(item.Color));
            }

            if (_filter.Material != null && _filter.Material.Length > 0) {
                query = query.Where(item => _filter.Material.Contains(item.Material));
            }

            if (_filter.Size != null && _filter.Size.Length > 0) {
                query = query.Where(item => _filter.Size.Contains(item.Size));
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
