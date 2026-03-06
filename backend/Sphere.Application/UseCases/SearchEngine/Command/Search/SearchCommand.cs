using Sphere.Application.Commons.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sphere.Application.UseCases.SearchEngine.Command.Search {
    public class SearchCommand : IUseCase<SearchResponse> {
        public string Query {  get; set; }
        public SearchCommand(string query) {
            Query = query;
        }
    }
}
