namespace Sphere.Application.UseCases.Categories.Queries.GetAll {
    public class GetAllCategoryResponse {
        public List<string> Categories { get; set; }

        public GetAllCategoryResponse(List<string> categories) {
            Categories = categories;
        }
    }
}
