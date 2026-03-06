using Sphere.Application.Commons.Interfaces;
using Sphere.Application.Commons.Interfaces.Services;

namespace Sphere.Application.UseCases.SearchEngine.Command.Search {
    public class SearchHandler : IUseCaseHandler<SearchCommand, SearchResponse> {
        private readonly ISearchEngineService _searchEngine;

        public SearchHandler(ISearchEngineService searchEngine) {
            _searchEngine = searchEngine;
        }

        public async Task<SearchResponse> Handle(SearchCommand request, CancellationToken ct) {
            var results = await _searchEngine.SearchAsync(request.Query, ct);
            return new SearchResponse(results);
        }
    }
}
