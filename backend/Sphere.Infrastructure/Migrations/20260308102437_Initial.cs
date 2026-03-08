using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sphere.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClothingImages");

            migrationBuilder.DropColumn(
                name: "SearchEngineId",
                table: "ClothingItems");

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "ClothingItems",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Images",
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
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClothingItems_ImageId",
                table: "ClothingItems",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClothingItems_Images_ImageId",
                table: "ClothingItems",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClothingItems_Images_ImageId",
                table: "ClothingItems");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropIndex(
                name: "IX_ClothingItems_ImageId",
                table: "ClothingItems");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "ClothingItems");

            migrationBuilder.AddColumn<string>(
                name: "SearchEngineId",
                table: "ClothingItems",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ClothingImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ClothingItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    ContentType = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FileName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClothingImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClothingImages_ClothingItems_ClothingItemId",
                        column: x => x.ClothingItemId,
                        principalTable: "ClothingItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClothingImages_ClothingItemId",
                table: "ClothingImages",
                column: "ClothingItemId",
                unique: true);
        }
    }
}
