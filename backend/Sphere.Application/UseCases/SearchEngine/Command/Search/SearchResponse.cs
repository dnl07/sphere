using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sphere.Application.UseCases.SearchEngine.Command.Search {
    public class SearchResponse {
        public List<Guid> Results { get; set; }
        public SearchResponse(List<Guid> results) {
            Results = results;
        }
    }
}
