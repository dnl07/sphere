namespace Sphere.Application.Commons.Models {
    public class PagedResult<T> {
        public List<T> Items { get; set; } = new List<T>();
        public int TotalCount { get; set; }
        public int PageCount { get; set;  }
        public int PageNumber { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
    }
}
