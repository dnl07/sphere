using Sphere.Application.Commons.Interfaces;
using Sphere.Application.Commons.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sphere.Application.UseCases.Category.Queries.GetAll {
    public class GetAllCategoryHandler : IUseCaseHandler<GetAllCategoryQuery, GetAllCategoryResponse> {
        private readonly ICategoryRepository _repository;

        public GetAllCategoryHandler(ICategoryRepository repository) {
            _repository = repository;
        }   

        public async Task<GetAllCategoryResponse> Handle(GetAllCategoryQuery request, CancellationToken ct) {
            var categories = await _repository.GetAllAsync(ct);

            return new GetAllCategoryResponse(categories.Select(c => c.Name).ToList());
        }
    }
}
