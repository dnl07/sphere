using Sphere.Application.Commons.Interfaces;

namespace Sphere.Application.UseCases.ClothingItems.Queries.Get {
    public class GetByIdQuery(Guid id) : IUseCase<GetByIdResponse> {
        public Guid Id { get; set; } = id;
    }
}