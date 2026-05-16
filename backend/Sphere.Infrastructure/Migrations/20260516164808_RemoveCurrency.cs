using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sphere.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCurrency : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceAmount",
                table: "ClothingItems");

            migrationBuilder.DropColumn(
                name: "PriceCurrency",
                table: "ClothingItems");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "ClothingItems",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0e2624ea-76f5-8940-bd80-4dad0885468b"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 16, 16, 48, 8, 69, DateTimeKind.Utc).AddTicks(5220), new DateTime(2026, 5, 16, 16, 48, 8, 69, DateTimeKind.Utc).AddTicks(5220) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("177d825b-36e8-d9ab-4b93-e03b212dbfe2"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 16, 16, 48, 8, 69, DateTimeKind.Utc).AddTicks(5137), new DateTime(2026, 5, 16, 16, 48, 8, 69, DateTimeKind.Utc).AddTicks(5138) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2aec747c-a90c-0c95-64f8-28fa155c3a0d"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 16, 16, 48, 8, 69, DateTimeKind.Utc).AddTicks(5213), new DateTime(2026, 5, 16, 16, 48, 8, 69, DateTimeKind.Utc).AddTicks(5214) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3c23e841-e0bb-ee3e-90cc-371b01175388"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 16, 16, 48, 8, 69, DateTimeKind.Utc).AddTicks(5185), new DateTime(2026, 5, 16, 16, 48, 8, 69, DateTimeKind.Utc).AddTicks(5185) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("464b5ae7-5b60-de3a-dcce-3e98dace883a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 16, 16, 48, 8, 69, DateTimeKind.Utc).AddTicks(5146), new DateTime(2026, 5, 16, 16, 48, 8, 69, DateTimeKind.Utc).AddTicks(5146) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("627a0da1-ffaa-2f59-4eec-bcf2fe7fad9b"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 16, 16, 48, 8, 69, DateTimeKind.Utc).AddTicks(5207), new DateTime(2026, 5, 16, 16, 48, 8, 69, DateTimeKind.Utc).AddTicks(5207) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("650a1cb3-a76d-1e45-246d-2d220f50a986"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 16, 16, 48, 8, 69, DateTimeKind.Utc).AddTicks(5200), new DateTime(2026, 5, 16, 16, 48, 8, 69, DateTimeKind.Utc).AddTicks(5200) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6a72b4cc-64c0-c5c7-411a-5a6f70a1dc70"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 16, 16, 48, 8, 69, DateTimeKind.Utc).AddTicks(5173), new DateTime(2026, 5, 16, 16, 48, 8, 69, DateTimeKind.Utc).AddTicks(5174) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6b0d6657-f7e4-ce7c-ccfd-861400f11e4d"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 16, 16, 48, 8, 69, DateTimeKind.Utc).AddTicks(5227), new DateTime(2026, 5, 16, 16, 48, 8, 69, DateTimeKind.Utc).AddTicks(5228) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7595c37a-01b7-93bc-aeb9-a7a1473a57c3"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 16, 16, 48, 8, 69, DateTimeKind.Utc).AddTicks(5169), new DateTime(2026, 5, 16, 16, 48, 8, 69, DateTimeKind.Utc).AddTicks(5170) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7953797d-9211-fb4b-a10d-3f98f1623a48"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 16, 16, 48, 8, 69, DateTimeKind.Utc).AddTicks(5203), new DateTime(2026, 5, 16, 16, 48, 8, 69, DateTimeKind.Utc).AddTicks(5204) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("841bc02f-5d0c-32ee-4551-211edad39bdf"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 16, 16, 48, 8, 69, DateTimeKind.Utc).AddTicks(5197), new DateTime(2026, 5, 16, 16, 48, 8, 69, DateTimeKind.Utc).AddTicks(5197) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8b4b0500-a80b-30c6-1761-1b99e6bf1f3f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 16, 16, 48, 8, 69, DateTimeKind.Utc).AddTicks(5142), new DateTime(2026, 5, 16, 16, 48, 8, 69, DateTimeKind.Utc).AddTicks(5142) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9734d588-a9f4-5829-c67c-73a9f2f52df3"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 16, 16, 48, 8, 69, DateTimeKind.Utc).AddTicks(5210), new DateTime(2026, 5, 16, 16, 48, 8, 69, DateTimeKind.Utc).AddTicks(5210) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9827f22f-a79a-da9a-d435-2223e419a145"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 16, 16, 48, 8, 69, DateTimeKind.Utc).AddTicks(5129), new DateTime(2026, 5, 16, 16, 48, 8, 69, DateTimeKind.Utc).AddTicks(5131) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a937c8eb-a54d-6fb0-d0be-cfb3cdaa92c0"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 16, 16, 48, 8, 69, DateTimeKind.Utc).AddTicks(5188), new DateTime(2026, 5, 16, 16, 48, 8, 69, DateTimeKind.Utc).AddTicks(5188) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b223cd6e-b69c-1818-8451-cdf0f35d4704"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 16, 16, 48, 8, 69, DateTimeKind.Utc).AddTicks(5166), new DateTime(2026, 5, 16, 16, 48, 8, 69, DateTimeKind.Utc).AddTicks(5166) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b9657e79-cdc5-a20d-5a93-2f2b0947b94b"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 16, 16, 48, 8, 69, DateTimeKind.Utc).AddTicks(5224), new DateTime(2026, 5, 16, 16, 48, 8, 69, DateTimeKind.Utc).AddTicks(5224) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c9aa9c37-9419-afd5-983d-32bd0a2f0557"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 16, 16, 48, 8, 69, DateTimeKind.Utc).AddTicks(5191), new DateTime(2026, 5, 16, 16, 48, 8, 69, DateTimeKind.Utc).AddTicks(5191) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("cb67e7c8-3faa-5411-6b37-2c04e36eb531"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 16, 16, 48, 8, 69, DateTimeKind.Utc).AddTicks(5177), new DateTime(2026, 5, 16, 16, 48, 8, 69, DateTimeKind.Utc).AddTicks(5177) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d1f37c34-1d7a-df71-9641-ba489fc0e0a0"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 16, 16, 48, 8, 69, DateTimeKind.Utc).AddTicks(5158), new DateTime(2026, 5, 16, 16, 48, 8, 69, DateTimeKind.Utc).AddTicks(5158) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d92e166e-bca2-3076-7e0a-249786f4951e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 16, 16, 48, 8, 69, DateTimeKind.Utc).AddTicks(5150), new DateTime(2026, 5, 16, 16, 48, 8, 69, DateTimeKind.Utc).AddTicks(5150) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d96fed16-c3cd-aebe-3c49-075184bb5b96"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 16, 16, 48, 8, 69, DateTimeKind.Utc).AddTicks(5181), new DateTime(2026, 5, 16, 16, 48, 8, 69, DateTimeKind.Utc).AddTicks(5181) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e99548c0-13c7-3264-78a3-df15426030cd"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 16, 16, 48, 8, 69, DateTimeKind.Utc).AddTicks(5154), new DateTime(2026, 5, 16, 16, 48, 8, 69, DateTimeKind.Utc).AddTicks(5154) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f1da3f64-f5fe-8d4e-ef75-1f54b706cd60"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 16, 16, 48, 8, 69, DateTimeKind.Utc).AddTicks(5217), new DateTime(2026, 5, 16, 16, 48, 8, 69, DateTimeKind.Utc).AddTicks(5217) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "ClothingItems");

            migrationBuilder.AddColumn<decimal>(
                name: "PriceAmount",
                table: "ClothingItems",
                type: "numeric(10,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PriceCurrency",
                table: "ClothingItems",
                type: "character varying(3)",
                maxLength: 3,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0e2624ea-76f5-8940-bd80-4dad0885468b"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 11, 8, 59, 14, 996, DateTimeKind.Utc).AddTicks(7739), new DateTime(2026, 5, 11, 8, 59, 14, 996, DateTimeKind.Utc).AddTicks(7739) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("177d825b-36e8-d9ab-4b93-e03b212dbfe2"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 11, 8, 59, 14, 996, DateTimeKind.Utc).AddTicks(7657), new DateTime(2026, 5, 11, 8, 59, 14, 996, DateTimeKind.Utc).AddTicks(7657) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2aec747c-a90c-0c95-64f8-28fa155c3a0d"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 11, 8, 59, 14, 996, DateTimeKind.Utc).AddTicks(7732), new DateTime(2026, 5, 11, 8, 59, 14, 996, DateTimeKind.Utc).AddTicks(7732) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3c23e841-e0bb-ee3e-90cc-371b01175388"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 11, 8, 59, 14, 996, DateTimeKind.Utc).AddTicks(7704), new DateTime(2026, 5, 11, 8, 59, 14, 996, DateTimeKind.Utc).AddTicks(7704) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("464b5ae7-5b60-de3a-dcce-3e98dace883a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 11, 8, 59, 14, 996, DateTimeKind.Utc).AddTicks(7665), new DateTime(2026, 5, 11, 8, 59, 14, 996, DateTimeKind.Utc).AddTicks(7665) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("627a0da1-ffaa-2f59-4eec-bcf2fe7fad9b"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 11, 8, 59, 14, 996, DateTimeKind.Utc).AddTicks(7725), new DateTime(2026, 5, 11, 8, 59, 14, 996, DateTimeKind.Utc).AddTicks(7725) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("650a1cb3-a76d-1e45-246d-2d220f50a986"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 11, 8, 59, 14, 996, DateTimeKind.Utc).AddTicks(7718), new DateTime(2026, 5, 11, 8, 59, 14, 996, DateTimeKind.Utc).AddTicks(7719) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6a72b4cc-64c0-c5c7-411a-5a6f70a1dc70"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 11, 8, 59, 14, 996, DateTimeKind.Utc).AddTicks(7694), new DateTime(2026, 5, 11, 8, 59, 14, 996, DateTimeKind.Utc).AddTicks(7694) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6b0d6657-f7e4-ce7c-ccfd-861400f11e4d"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 11, 8, 59, 14, 996, DateTimeKind.Utc).AddTicks(7745), new DateTime(2026, 5, 11, 8, 59, 14, 996, DateTimeKind.Utc).AddTicks(7746) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7595c37a-01b7-93bc-aeb9-a7a1473a57c3"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 11, 8, 59, 14, 996, DateTimeKind.Utc).AddTicks(7690), new DateTime(2026, 5, 11, 8, 59, 14, 996, DateTimeKind.Utc).AddTicks(7690) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7953797d-9211-fb4b-a10d-3f98f1623a48"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 11, 8, 59, 14, 996, DateTimeKind.Utc).AddTicks(7722), new DateTime(2026, 5, 11, 8, 59, 14, 996, DateTimeKind.Utc).AddTicks(7722) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("841bc02f-5d0c-32ee-4551-211edad39bdf"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 11, 8, 59, 14, 996, DateTimeKind.Utc).AddTicks(7715), new DateTime(2026, 5, 11, 8, 59, 14, 996, DateTimeKind.Utc).AddTicks(7716) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8b4b0500-a80b-30c6-1761-1b99e6bf1f3f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 11, 8, 59, 14, 996, DateTimeKind.Utc).AddTicks(7661), new DateTime(2026, 5, 11, 8, 59, 14, 996, DateTimeKind.Utc).AddTicks(7661) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9734d588-a9f4-5829-c67c-73a9f2f52df3"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 11, 8, 59, 14, 996, DateTimeKind.Utc).AddTicks(7728), new DateTime(2026, 5, 11, 8, 59, 14, 996, DateTimeKind.Utc).AddTicks(7729) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9827f22f-a79a-da9a-d435-2223e419a145"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 11, 8, 59, 14, 996, DateTimeKind.Utc).AddTicks(7650), new DateTime(2026, 5, 11, 8, 59, 14, 996, DateTimeKind.Utc).AddTicks(7651) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a937c8eb-a54d-6fb0-d0be-cfb3cdaa92c0"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 11, 8, 59, 14, 996, DateTimeKind.Utc).AddTicks(7709), new DateTime(2026, 5, 11, 8, 59, 14, 996, DateTimeKind.Utc).AddTicks(7709) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b223cd6e-b69c-1818-8451-cdf0f35d4704"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 11, 8, 59, 14, 996, DateTimeKind.Utc).AddTicks(7687), new DateTime(2026, 5, 11, 8, 59, 14, 996, DateTimeKind.Utc).AddTicks(7687) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b9657e79-cdc5-a20d-5a93-2f2b0947b94b"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 11, 8, 59, 14, 996, DateTimeKind.Utc).AddTicks(7742), new DateTime(2026, 5, 11, 8, 59, 14, 996, DateTimeKind.Utc).AddTicks(7742) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c9aa9c37-9419-afd5-983d-32bd0a2f0557"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 11, 8, 59, 14, 996, DateTimeKind.Utc).AddTicks(7712), new DateTime(2026, 5, 11, 8, 59, 14, 996, DateTimeKind.Utc).AddTicks(7712) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("cb67e7c8-3faa-5411-6b37-2c04e36eb531"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 11, 8, 59, 14, 996, DateTimeKind.Utc).AddTicks(7697), new DateTime(2026, 5, 11, 8, 59, 14, 996, DateTimeKind.Utc).AddTicks(7697) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d1f37c34-1d7a-df71-9641-ba489fc0e0a0"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 11, 8, 59, 14, 996, DateTimeKind.Utc).AddTicks(7682), new DateTime(2026, 5, 11, 8, 59, 14, 996, DateTimeKind.Utc).AddTicks(7682) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d92e166e-bca2-3076-7e0a-249786f4951e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 11, 8, 59, 14, 996, DateTimeKind.Utc).AddTicks(7669), new DateTime(2026, 5, 11, 8, 59, 14, 996, DateTimeKind.Utc).AddTicks(7669) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d96fed16-c3cd-aebe-3c49-075184bb5b96"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 11, 8, 59, 14, 996, DateTimeKind.Utc).AddTicks(7700), new DateTime(2026, 5, 11, 8, 59, 14, 996, DateTimeKind.Utc).AddTicks(7701) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e99548c0-13c7-3264-78a3-df15426030cd"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 11, 8, 59, 14, 996, DateTimeKind.Utc).AddTicks(7678), new DateTime(2026, 5, 11, 8, 59, 14, 996, DateTimeKind.Utc).AddTicks(7679) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f1da3f64-f5fe-8d4e-ef75-1f54b706cd60"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 11, 8, 59, 14, 996, DateTimeKind.Utc).AddTicks(7736), new DateTime(2026, 5, 11, 8, 59, 14, 996, DateTimeKind.Utc).AddTicks(7736) });
        }
    }
}
