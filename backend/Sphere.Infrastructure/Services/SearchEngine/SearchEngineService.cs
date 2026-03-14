using Microsoft.Extensions.Logging;
using Sphere.Application.Commons.Interfaces.Services;
using Sphere.Domain.ClothingItems;
using Sphere.Infrastructure.Services.SearchEngine.Models;
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
            try {
                var statusResponse = await _client.GetFromJsonAsync<EngineStatus>("engine/status", ct);

                if (statusResponse?.IsInitialized == true) {
                    _logger.LogInformation("Search engine is already initialized according to status check.");
                    return;
                }

                var options = new IndexOptions { UseOwnIds = true };

                var response = await _client.PostAsJsonAsync("engine/init", options, ct);
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

            try {
                var response = await _client.PostAsJsonAsync(url, indexItem, ct);
                var deserialized = await response.Content.ReadFromJsonAsync<IndexedResponse>(cancellationToken: ct);

                _logger.LogDebug("Item {name} successfully indexed", indexItem.Title);

                return deserialized?.AddedDocuments.FirstOrDefault()?.Id.ToString() ?? string.Empty;

            } catch (Exception e) {
                _logger.LogError(e, "Error occurred while indexing item: {Name}", indexItem.Title);
                throw;
            }
        }

        public async Task UpdateItemAsync(SearchIndexItem indexItem, CancellationToken ct) {
            var url = $"documents/update/{indexItem.Id}";

            try {
                var response = await _client.PutAsJsonAsync(url, indexItem, ct);

                response.EnsureSuccessStatusCode();

                _logger.LogInformation("Item {name} successfully updated in search index", indexItem.Title);

            } catch (Exception e) {
                _logger.LogError(e, "Error occurred while updating item: {Name}", indexItem.Title);
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
