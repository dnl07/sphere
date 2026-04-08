namespace Sphere.Application.Commons.Models {
    public class SearchIndexItem {
        public Guid Id { get; set; }
        public string Title { get; set; } = "";
        public string? Description { get; set; } = "";
        public string[]? Tags { get; set; } = [];
    }
}
