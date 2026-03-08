using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Sphere.Application.Commons.Interfaces.Repository;
using Sphere.Application.Commons.Interfaces.Services;

namespace Sphere.Infrastructure.Services.SearchEngine {
    public static class SearchEngineInitializer {
        /// <summary>
        /// Initializes the search engine by waiting for it to be available and then indexing existing items from the database.
        /// </summary>
        public static async Task InitializeAsync(IServiceProvider serviceProvider, CancellationToken ct = default) {
            using var scope = serviceProvider.CreateScope();

            var searchEngine = scope.ServiceProvider.GetRequiredService<ISearchEngineService>();
            var repo = scope.ServiceProvider.GetRequiredService<IClothingItemRepository>();
            var logger = scope.ServiceProvider.GetRequiredService<ILoggerFactory>().CreateLogger("SearchEngineInitializer");
            logger.LogInformation("Waiting for search engine container...");

            await WaitForSearchEngineAsync(searchEngine, logger, ct);
            await IndexExistingItemsAsync(searchEngine, repo, logger, ct);
        }

        /// <summary>
        /// Waits for the search engine to be available by repeatedly trying to initialize 
        /// it until it succeeds or a maximum number of retries is reached.
        /// </summary>
        private static async Task WaitForSearchEngineAsync(ISearchEngineService searchEngine, ILogger logger, CancellationToken ct) {
            var maxRetries = 10;

            logger.LogInformation("Waiting for search engine container...");
            await Task.Delay(TimeSpan.FromSeconds(3), ct);

            // Try to initialize the search engine with retries
            for (int i = 0; i < maxRetries; i++) {
                try {
                    logger.LogInformation("Initializing search engine (attempt {Attempt}/{MaxRetries})...", i + 1, maxRetries);
                    await searchEngine.InitializeAsync(ct);
                    logger.LogInformation("Search engine initialized successfully");
                    return;
                } catch (Exception ex) {
                    logger.LogWarning(ex, "Attempt {Attempt} failed: {Message}", i + 1, ex.Message);

                    if (i < maxRetries - 1) {
                        await Task.Delay(TimeSpan.FromSeconds(3), ct);
                    }
                }
            }
        }

        /// <summary>
        /// Indexes existing clothing items from the database into the search engine. 
        /// </summary>
        private static async Task IndexExistingItemsAsync(ISearchEngineService searchEngine, IClothingItemRepository repo, ILogger logger, CancellationToken ct) {
            var items = await repo.GetAllAsync();
            logger.LogInformation("SearchEngine: Indexing {Count} items...", items.Count);

            foreach (var item in items) {
                try {
                    var indexItem = new SearchIndexItem {
                        Id = item.Id,
                        Name = item.Name,
                        Description = item.Description
                    };
                    await searchEngine.IndexItemAsync(indexItem, ct);
                    logger.LogDebug("SearchEngine: Indexed {ItemId}", item.Id);
                } catch (Exception e) {
                    logger.LogError(e, "SearchEngine: Failed to index {ItemId}", item.Id);
                }
            }
        }
    }
}
