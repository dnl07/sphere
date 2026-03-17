using Sphere.Application.Commons.Interfaces;

namespace Sphere.Application.UseCases.SearchEngine.Command.Search {
    public class SearchCommand(string query) : IUseCase<SearchResponse> {
        public string Query { get; set; } = query;
    }
}