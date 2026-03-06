using Sphere.Application.Commons.Interfaces;

namespace Sphere.Application.UseCases.SearchEngine.Command.Search {
    public class SearchCommand : IUseCase<SearchResponse> {
        public string Query {  get; set; }
        public SearchCommand(string query) {
            Query = query;
        }
    }
}
