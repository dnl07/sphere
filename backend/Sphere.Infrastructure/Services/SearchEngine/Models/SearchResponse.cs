namespace Sphere.Infrastructure.Services.SearchEngine.Models {
    public class SearchResponse {
        public SearchHit[] Hits { get; set; } = [];
    }

    public class SearchHit {
        public Guid Id { get; set; }
    }
}
