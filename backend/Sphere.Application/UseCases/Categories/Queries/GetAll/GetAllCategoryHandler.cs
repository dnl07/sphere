using Microsoft.Extensions.Logging;
using Sphere.Application.Commons.Interfaces;
using Sphere.Application.Commons.Interfaces.Repository;

namespace Sphere.Application.UseCases.Categories.Queries.GetAll {
    public class GetAllCategoryHandler : IUseCaseHandler<GetAllCategoryQuery, GetAllCategoryResponse> {
        private readonly IClothingItemRepository _repository;
        private readonly ILogger<GetAllCategoryHandler> _logger;

        public GetAllCategoryHandler(IClothingItemRepository repository, ILogger<GetAllCategoryHandler> logger) {
            _repository = repository;
            _logger = logger;
        }   

        public async Task<GetAllCategoryResponse> Handle(GetAllCategoryQuery request, CancellationToken ct) {
            _logger.LogInformation("Retrieving all categories");

            var categories = await _repository.GetAllCategoriesAsync(ct);

            return new GetAllCategoryResponse(categories.Select(c => c.Name).ToList());
        }
    }
}
