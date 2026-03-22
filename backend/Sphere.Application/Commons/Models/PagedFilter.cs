namespace Sphere.Application.Commons.Models {
    public class PagedFilter {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public int? FromPage { get; set; }
        public int? ToPage { get; set; }
    }
}
