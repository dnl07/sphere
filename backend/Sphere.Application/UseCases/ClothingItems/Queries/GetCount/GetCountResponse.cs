namespace Sphere.Application.UseCases.ClothingItems.Queries.GetCount {
    public class GetCountResponse {
        public int Count { get; }

        public GetCountResponse(int count) {
            Count = count;
        }
    }
}
