using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sphere.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClothingItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Size = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Material = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Color = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    PriceAmount = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    PriceCurrency = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    BoughtAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Store = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    ImageId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClothingItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MediaFiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FileName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
                    ContentType = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaFiles", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0e2624ea-76f5-8940-bd80-4dad0885468b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sneakers", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("177d825b-36e8-d9ab-4b93-e03b212dbfe2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Long Sleeve Shirt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2aec747c-a90c-0c95-64f8-28fa155c3a0d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Scarf", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3c23e841-e0bb-ee3e-90cc-371b01175388"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dress", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("464b5ae7-5b60-de3a-dcce-3e98dace883a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jacket", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("627a0da1-ffaa-2f59-4eec-bcf2fe7fad9b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hat", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("650a1cb3-a76d-1e45-246d-2d220f50a986"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cardigan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6a72b4cc-64c0-c5c7-411a-5a6f70a1dc70"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Leggings", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6b0d6657-f7e4-ce7c-ccfd-861400f11e4d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "High Heels", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7595c37a-01b7-93bc-aeb9-a7a1473a57c3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shorts", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7953797d-9211-fb4b-a10d-3f98f1623a48"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hoodie", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("841bc02f-5d0c-32ee-4551-211edad39bdf"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pullover", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8b4b0500-a80b-30c6-1761-1b99e6bf1f3f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Blouse", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9734d588-a9f4-5829-c67c-73a9f2f52df3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cap", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9827f22f-a79a-da9a-d435-2223e419a145"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "T-Shirt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a937c8eb-a54d-6fb0-d0be-cfb3cdaa92c0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Skirt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b223cd6e-b69c-1818-8451-cdf0f35d4704"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pants", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b9657e79-cdc5-a20d-5a93-2f2b0947b94b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Boots", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c9aa9c37-9419-afd5-983d-32bd0a2f0557"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sweater", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cb67e7c8-3faa-5411-6b37-2c04e36eb531"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Joggers", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d1f37c34-1d7a-df71-9641-ba489fc0e0a0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jeans", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d92e166e-bca2-3076-7e0a-249786f4951e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Coat", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d96fed16-c3cd-aebe-3c49-075184bb5b96"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sweatpants", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e99548c0-13c7-3264-78a3-df15426030cd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Blazer", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f1da3f64-f5fe-8d4e-ef75-1f54b706cd60"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gloves", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "ClothingItems");

            migrationBuilder.DropTable(
                name: "MediaFiles");
        }
    }
}
