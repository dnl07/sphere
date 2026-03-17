namespace Sphere.Application.UseCases.ClothingItems.Queries.GetAll {
    public class ClothingItemFilter {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Color { get; set; }
        public string? Size { get; set; }
        public string? Material { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public bool FetchAll { get; set; } = false;
        public string? SortBy { get; set; }
        public bool SortOrdner { get; set; } = false;
    }
}