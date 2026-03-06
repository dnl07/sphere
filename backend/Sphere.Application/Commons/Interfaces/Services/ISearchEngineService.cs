namespace Sphere.Application.Commons.Interfaces.Services {
    public interface ISearchEngineService {
        Task InitializeAsync(CancellationToken ct);
        Task<List<Guid>> SearchAsync(string query, CancellationToken ct);
        Task<string> IndexItemAsync(SearchIndexItem indexItem, CancellationToken ct);
        Task RemoveItemAsync(Guid searchEngineId, CancellationToken ct);
    }
}
