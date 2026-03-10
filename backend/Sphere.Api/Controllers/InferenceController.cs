using Microsoft.AspNetCore.Mvc;
using Sphere.Api.Dtos.Requests;
using Sphere.Api.Utils;
using Sphere.Application.Commons.Interfaces;
using Sphere.Application.UseCases.Inference.Commands.Create;

namespace Sphere.Api.Controllers {
    [ApiController]
    [Route("api/inference")]
    [Produces("application/json")]
    public class InferenceController : ControllerBase {
        private readonly IUseCaseDispatcher _dispatcher;
        public InferenceController(IUseCaseDispatcher dispatcher) {
            _dispatcher = dispatcher;
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Inference([FromForm] CreateInferenceRequestDto request) {
            var command = new CreateInferenceCommand(request.Image.ConvertToBytes());

            var response = await _dispatcher.Dispatch(command);

            if (response is null) {
                return NotFound();
            }

            return File(response.CroppedImageData, "image/png", fileDownloadName: "image");
        }
    }
}
