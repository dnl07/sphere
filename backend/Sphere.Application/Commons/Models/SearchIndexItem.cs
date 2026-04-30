using System.Text.Json.Serialization;

namespace Sphere.Application.Commons.Models {
    public class SearchIndexItem {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; } = "";

        [JsonPropertyName("description")]
        public string? Description { get; set; } = "";

        [JsonPropertyName("tags")]
        public string[]? Tags { get; set; } = [];

        [JsonPropertyName("metadata")]
        public Dictionary<string, string>? Metadata { get; set; } = new Dictionary<string, string>();
    }
}
