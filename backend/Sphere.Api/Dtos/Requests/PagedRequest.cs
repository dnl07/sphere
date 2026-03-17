namespace Sphere.Api.Dtos.Requests {
    public class PagedRequest {
        public bool FetchAll { get; set; } = false;
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? FromPage { get; set; }
        public int? ToPage { get; set; }
    }   
}