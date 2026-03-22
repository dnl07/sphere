using Microsoft.AspNetCore.Mvc;
using Sphere.Application.Commons.Interfaces;
using Sphere.Application.UseCases.Search.Command.Search;

namespace Sphere.Api.Controllers {
    [ApiController]
    [Route("api/search")]
    [Produces("application/json")]
    public class SearchController : ControllerBase {
        private readonly IUseCaseDispatcher _dispatcher;

        public SearchController(IUseCaseDispatcher dispatcher) {
            _dispatcher = dispatcher;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Search([FromQuery] string query) {
            var command = new SearchCommand(query);
            var response = await _dispatcher.Dispatch<SearchResponse>(command);

            return Ok(response);
        }
    }
}
