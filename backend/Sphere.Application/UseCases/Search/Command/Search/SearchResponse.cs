namespace Sphere.Application.UseCases.Search.Command.Search {
    public class SearchResponse {
        public SearchResultItem[] Results { get; set; }
        public SearchResponse(SearchResultItem[] results) {
            Results = results;
        }
    }

    public class SearchResultItem {
        public Guid Id { get; }
        public string? Category { get; }
        public string? Size { get; }
        public string? Material { get; }
        public string? Color { get; }
        public decimal? PriceAmount { get; }
        public string? PriceCurrency { get; }
        public Guid ImageId { get; }

        public SearchResultItem(
            Guid id,
            string? category,
            string? size,
            string? material,
            string? color,
            decimal? priceAmount,
            string? priceCurrency,
            Guid imageId
        ) {
            Id = id;
            Category = category;
            Size = size;
            Material = material;
            Color = color;
            PriceAmount = priceAmount;
            PriceCurrency = priceCurrency;
            ImageId = imageId;
        }
    }
}
