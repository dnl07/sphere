using Sphere.Application.Commons.Interfaces;

namespace Sphere.Application.UseCases.Search.Command.Search {
    public class SearchCommand(string query) : IUseCase<SearchResponse> {
        public string Query { get; set; } = query;
    }
}