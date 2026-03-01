using Microsoft.AspNetCore.Mvc;
using Sphere.API.Dtos.Requests;
using Sphere.API.Mappers;
using Sphere.Application.Commons.Interfaces;
using Sphere.Application.UseCases.ClothingItems.Commands.Get;

namespace Sphere.API.Controllers
{
    [ApiController]
    [Route("api/clothing")]
    public class ClothingController : ControllerBase {
        private readonly IUseCaseDispatcher _dispatcher;

        public ClothingController(IUseCaseDispatcher dispatcher) {
            _dispatcher = dispatcher;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateClothingItemRequestDto request) {
            var command = request.ToCommand();

            var response = await _dispatcher.Dispatch(command);

            return Ok(response);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id) {
            var query = new GetClothingItemQuery(id);

            var response = await _dispatcher.Dispatch(query);

            if (response is null) {
                return NotFound();
            }

            return Ok(response);
        }
    }
}
