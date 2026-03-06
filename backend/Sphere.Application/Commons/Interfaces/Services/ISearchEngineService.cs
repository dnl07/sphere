namespace Sphere.Application.Commons.Interfaces.Services {
    public interface ISearchEngineService {
        Task<List<Guid>> SearchAsync(string query, CancellationToken ct);
        Task<string> IndexItemAsync(string Name, string? Description, CancellationToken ct);
        Task RemoveItemAsync(Guid searchEngineId, CancellationToken ct);
    }
}
