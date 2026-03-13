using Sphere.Application.Commons.Interfaces;
using Sphere.Application.Commons.Interfaces.Repository;

namespace Sphere.Application.UseCases.Category.Queries.GetAll {
    public class GetAllCategoryHandler : IUseCaseHandler<GetAllCategoryQuery, GetAllCategoryResponse> {
        private readonly IClothingItemRepository _repository;

        public GetAllCategoryHandler(IClothingItemRepository repository) {
            _repository = repository;
        }   

        public async Task<GetAllCategoryResponse> Handle(GetAllCategoryQuery request, CancellationToken ct) {
            var categories = await _repository.GetAllCategoriesAsync(ct);

            return new GetAllCategoryResponse(categories.Select(c => c.Name).ToList());
        }
    }
}
