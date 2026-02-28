using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sphere.API.Dtos.Requests;
using Sphere.API.Mappers;

namespace Sphere.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClothingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClothingController(IMediator mediator) {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateClothingItemRequestDto request) {
            var command = request.ToCommand();

            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
