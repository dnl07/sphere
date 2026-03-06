namespace Sphere.Infrastructure.Services.SearchEngine {
    public class Document {
        public Guid Id { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
    }
}
