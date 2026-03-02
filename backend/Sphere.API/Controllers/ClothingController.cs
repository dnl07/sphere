using Microsoft.AspNetCore.Mvc;
using Sphere.API.Dtos.Requests;
using Sphere.API.Mappers;
using Sphere.Application.Commons.Interfaces;
using Sphere.Application.UseCases.ClothingImage.Queries.Get;
using Sphere.Application.UseCases.ClothingItem.Commands.Delete;
using Sphere.Application.UseCases.ClothingItems.Queries.GetAll;

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
        public async Task<IActionResult> Create([FromForm] CreateClothingItemRequestDto request) {
            var command = request.ToCommand();

            var response = await _dispatcher.Dispatch(command);

            return Ok(response);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id) {
            var query = new GetClothingImageQuery(id);

            var response = await _dispatcher.Dispatch(query);

            if (response is null) {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpGet("get/all")]
        public async Task<IActionResult> GetAll() {
            var query = new GetAllClothingItemQuery();

            var response = await _dispatcher.Dispatch(query);

            if (response is null) {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpGet("delete/{id}")]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id) {
            var query = new DeleteClothingItemCommand(id);

            var response = await _dispatcher.Dispatch(query);

            if (response is null) {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpGet("{itemId}/image")]
        public async Task<IActionResult> GetImageById([FromRoute] Guid itemId) {
            var query = new GetClothingImageQuery(itemId);
             
            var response = await _dispatcher.Dispatch(query);

            if (response is null) {
                return NotFound();
            }

            return Ok(response);
        }
    }
}
