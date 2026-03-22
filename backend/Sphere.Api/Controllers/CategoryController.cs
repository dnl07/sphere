using Microsoft.AspNetCore.Mvc;
using Sphere.Application.Commons.Interfaces;
using Sphere.Application.UseCases.Categories.Queries.GetAll;

namespace Sphere.Api.Controllers {
    [ApiController]
    [Route("api/category")]
    [Produces("application/json")]
    public class CategoryController : ControllerBase {
        private readonly IUseCaseDispatcher _dispatcher;

        public CategoryController(IUseCaseDispatcher dispatcher) {
            _dispatcher = dispatcher;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll() {
            var query = new GetAllCategoryQuery();

            var response = await _dispatcher.Dispatch(query);

            if (response is null) {
                return NotFound();
            }

            return Ok(response);
        }
    }
}