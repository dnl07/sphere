using Microsoft.Extensions.Logging;
using Sphere.Application.Commons.Interfaces.Services;
using System.Net.Http.Json;

namespace Sphere.Infrastructure.Services.SearchEngine {
    public class SearchEngineService : ISearchEngineService {
        private readonly HttpClient _client;
        private readonly ILogger<SearchEngineService> _logger;

        public SearchEngineService(HttpClient client, ILogger<SearchEngineService> logger) {
            _client = client;
            _logger = logger;
        }

        public async Task InitializeAsync(CancellationToken ct) {
            var url = "engine/init";

            var options = new {
                useOwnId = true
            };

            try {
                var response = await _client.PostAsJsonAsync(url, options);
                response.EnsureSuccessStatusCode();
                _logger.LogInformation("Search engine initialized successfully");
            } catch (Exception e) {
                _logger.LogError(e, "Error occurred while initializing search engine");
                throw;
            }
        }

        public async Task<List<Guid>> SearchAsync(string query, CancellationToken ct = default) {
            var encoded = Uri.EscapeDataString(query);
            var url = $"search?query={Uri.EscapeDataString(query)}";

            try {
                var response = await _client.GetFromJsonAsync<SearchResponse>(url, cancellationToken: ct);

                if (response is null) {
                    _logger.LogWarning("Search response was null for query: {Query}", query);
                    return new List<Guid>();
                }

                var ids = response.Hits.Select(hit => hit.Id).ToList();
                _logger.LogDebug("Search for query: {Query} returned {Count} results", query, ids.Count);

                return ids;

            } catch (Exception e) {
                _logger.LogError(e, "Error occurred while searching for query: {Query}", query);
                throw;
            }
        }

        public async Task<string> IndexItemAsync(SearchIndexItem indexItem, CancellationToken ct = default) {
            var url = "documents/add";

            var request = new Document {
                Id = indexItem.Id,
                Title = indexItem.Name,
                Description = indexItem.Description ?? string.Empty
            };

            try {
                var response = await _client.PostAsJsonAsync(url, request, ct);
                var deserialized = await response.Content.ReadFromJsonAsync<IndexedResponse>(cancellationToken: ct);

                _logger.LogDebug("Item {name} successfully indexed", indexItem.Name);

                // Assuming the response contains the ID of the indexed document
                return deserialized?.AddedDocuments.FirstOrDefault()?.Id.ToString() ?? string.Empty;

            } catch (Exception e) {
                _logger.LogError(e, "Error occurred while indexing item: {Name}", indexItem.Name);
                throw;
            }
        }

        public async Task RemoveItemAsync(Guid clothingItemId, CancellationToken ct = default) {
            var url = $"documents/remove/{clothingItemId}";
            try {
                var response = await _client.DeleteAsync(url, ct);
                response.EnsureSuccessStatusCode();
                _logger.LogDebug("Item with ID {Id} successfully removed from search index", clothingItemId);
            } catch (Exception e) {
                _logger.LogError(e, "Error occurred while removing item with ID: {Id}", clothingItemId);
                throw;
            }
        }
    }
}
