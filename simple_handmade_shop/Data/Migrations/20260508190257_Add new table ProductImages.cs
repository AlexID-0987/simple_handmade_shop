using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace simple_handmade_shop.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddnewtableProductImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "ImageUrl", "ProductId" },
                values: new object[,]
                {
                    { 1, "/photo/Без названия.jpg", 1 },
                    { 2, "/photo/lav.jpg", 1 },
                    { 3, "/photo/lavanda.jpg", 1 },
                    { 4, "/photo/lavandawood.jpg", 2 },
                    { 5, "/photo/Без названия.jpg", 2 },
                    { 6, "/photo/lav.jpg", 2 },
                    { 7, "/photo/lavanda.jpg", 3 },
                    { 8, "/photo/lavandawood.jpg", 3 },
                    { 9, "/photo/lav.jpg", 4 },
                    { 10, "/photo/lavanda.jpg", 4 },
                    { 11, "/photo/lavandawood.jpg", 4 },
                    { 12, "/photo/lav.jpg", 5 },
                    { 13, "/photo/lavanda.jpg", 5 },
                    { 14, "/photo/lavandawood.jpg", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImages");
        }
    }
}
