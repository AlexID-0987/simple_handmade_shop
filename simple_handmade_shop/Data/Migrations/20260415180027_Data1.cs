using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace simple_handmade_shop.Data.Migrations
{
    /// <inheritdoc />
    public partial class Data1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, "A beautifully crafted wooden chair made from high-quality materials.", "https://example.com/images/wooden-chair.jpg", "Handmade Wooden Chair", 149.99m, 0 },
                    { 2, "An elegant ceramic vase with intricate designs, perfect for home decor.", "https://example.com/images/ceramic-vase.jpg", "Handmade Ceramic Vase", 79.99m, 0 },
                    { 3, "A stylish and durable leather wallet that combines functionality with craftsmanship.", "https://example.com/images/leather-wallet.jpg", "Handmade Leather Wallet", 59.99m, 0 },
                    { 4, "A cozy and fashionable knitted scarf made from soft yarn, ideal for chilly days.", "https://example.com/images/knitted-scarf.jpg", "Handmade Knitted Scarf", 39.99m, 0 },
                    { 5, "A sturdy and attractive wooden cutting board that adds a rustic touch to your kitchen.", "https://example.com/images/cutting-board.jpg", "Handmade Wooden Cutting Board", 29.99m, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
