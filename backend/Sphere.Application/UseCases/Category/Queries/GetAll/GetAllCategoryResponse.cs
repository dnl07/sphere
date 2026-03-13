namespace Sphere.Application.UseCases.Category.Queries.GetAll {
    public class GetAllCategoryResponse {
        public List<string> Categories { get; set; }

        public GetAllCategoryResponse(List<string> categories) {
            Categories = categories;
        }
    }
}
