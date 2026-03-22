namespace Sphere.Api.Dtos.Requests.Commons {
    public class PagedRequest {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public int? FromPage { get; set; }
        public int? ToPage { get; set; }
    }   
}