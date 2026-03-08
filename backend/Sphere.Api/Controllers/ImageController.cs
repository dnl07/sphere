using Microsoft.AspNetCore.Mvc;
using Sphere.Application.Commons.Interfaces;
using Sphere.Application.UseCases.Image.Queries.Get;

namespace Sphere.Api.Controllers {
    [ApiController]
    [Route("api/image")]
    [Produces("application/json")]
    public class ImageController : ControllerBase {
        private readonly IUseCaseDispatcher _dispatcher;

        public ImageController(IUseCaseDispatcher dispatcher) {
            _dispatcher = dispatcher;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([FromRoute] Guid id) {
            var query = new GetImageQuery(id);

            var response = await _dispatcher.Dispatch(query);

            if (response is null) {
                return NotFound();
            }

            return File(response.FileData, response.ContentType, fileDownloadName: response.FileName);
        }
    }
}