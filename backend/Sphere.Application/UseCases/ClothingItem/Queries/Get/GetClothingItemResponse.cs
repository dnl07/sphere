namespace Sphere.Application.UseCases.ClothingItems.Queries.Get {
    public class GetClothingItemResponse {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public GetClothingItemResponse(Guid id, string name) {
            Id = id;
            Name = name;
        }
    }
}
