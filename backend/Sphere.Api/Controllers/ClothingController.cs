using Microsoft.AspNetCore.Mvc;
using Sphere.Api.Dtos.Requests.ClothingItems;
using Sphere.API.Mappers;
using Sphere.Application.Commons.Interfaces;
using Sphere.Application.UseCases.ClothingItem.Commands.Delete;
using Sphere.Application.UseCases.ClothingItem.Queries.GetItems;
using Sphere.Application.UseCases.ClothingItems.Queries.Get;
using Sphere.Application.UseCases.Image.Queries.Get;

namespace Sphere.API.Controllers
{
    [ApiController]
    [Route("api/clothing")]
    [Produces("application/json")]
    public class ClothingController : ControllerBase {
        private readonly IUseCaseDispatcher _dispatcher;

        public ClothingController(IUseCaseDispatcher dispatcher) {
            _dispatcher = dispatcher;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromForm] CreateClothingItemRequestDto request) {
            var command = request.ToCreateCommand();
            var response = await _dispatcher.Dispatch(command);

            return Ok(response);
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetClothingItems([FromQuery] ClothingItemFilterRequest request, CancellationToken ct) {
            var query = new GetItemsQuery(request.ToFilter());
            var response = await _dispatcher.Dispatch(query);

            if (response is null) {
                return NotFound();
            }

            return Ok(response);
            
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id) {
            var query = new GetByIdQuery(id);
            var response = await _dispatcher.Dispatch(query);

            if (response is null) {
                return NotFound();
            }

            return Ok(response);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateById(string id, [FromForm] UpdateClothingItemRequestDto request) {
            if (!Guid.TryParse(id, out var guidId)) {
                return BadRequest("Invalid ID format.");
            }

            var command = request.ToUpdateCommand(guidId);

            var response = await _dispatcher.Dispatch(command);

            if (response is null) {
                return NotFound();
            }

            return Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id) {
            var query = new DeleteClothingItemCommand(id);
            var response = await _dispatcher.Dispatch(query);

            if (response is null) {
                return NotFound();
            }

            return Ok();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{itemId}/image")]
        public async Task<IActionResult> GetImageById([FromRoute] Guid itemId) {
            var query = new GetMediaFileQuery(itemId);
            var response = await _dispatcher.Dispatch(query);

            if (response is null) {
                return NotFound();
            }

            return File(response.FileData, response.ContentType, response.FileName);
        }
    }
}
