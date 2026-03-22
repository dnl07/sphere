namespace Sphere.Application.UseCases.Search.Command.Search {
    public class SearchResponse {
        public SearchResultItem[] Results { get; set; }
        public SearchResponse(SearchResultItem[] results) {
            Results = results;
        }
    }

    public class SearchResultItem {
        public Guid Id { get; }
        public string Name { get; }
        public string? Category { get; }
        public string? Description { get; }
        public string? Size { get; }
        public string? Material { get; }
        public string? Color { get; }
        public decimal? PriceAmount { get; }
        public string? PriceCurrency { get; }
        public Guid ImageId { get; }

        public SearchResultItem(
            Guid id,
            string name,
            string? category,
            string? description,
            string? size,
            string? material,
            string? color,
            decimal? priceAmount,
            string? priceCurrency,
            Guid imageId
        ) {
            Id = id;
            Name = name;
            Category = category;
            Description = description;
            Size = size;
            Material = material;
            Color = color;
            PriceAmount = priceAmount;
            PriceCurrency = priceCurrency;
            ImageId = imageId;
        }
    }
}
