namespace Sphere.Application.UseCases.SearchEngine.Command.Search {
    public class SearchResponse {
        public List<Guid> Results { get; set; }
        public SearchResponse(List<Guid> results) {
            Results = results;
        }
    }
}
