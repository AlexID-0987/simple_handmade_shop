using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace simple_handmade_shop.Data.Migrations
{
    /// <inheritdoc />
    public partial class addproperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullDescription",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "FullDescription",
                value: "This handmade wooden chair is a perfect blend of craftsmanship and comfort. Made from high-quality wood, it features a sturdy frame and a comfortable seat. The intricate design adds a touch of elegance to any room, making it a great addition to your home decor.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "FullDescription",
                value: "This elegant ceramic vase is a true work of art, featuring intricate designs that showcase the skill of the artisan. Its unique shape and beautiful glaze make it a stunning centerpiece for any room.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "FullDescription",
                value: " This handmade leather wallet is crafted from high-quality leather, ensuring durability and a timeless look. It features multiple compartments for cards, cash, and coins, making it both practical and stylish. The attention to detail in the stitching and design reflects the skill of the artisan, making it a perfect accessory for everyday use.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "FullDescription",
                value: "This cozy knitted scarf is made from soft, high-quality yarn, providing warmth and comfort during chilly days. Its fashionable design makes it a versatile accessory that can be worn in various styles, adding a touch of elegance to any outfit.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "FullDescription",
                value: "This sturdy wooden cutting board is not only functional but also adds a rustic touch to your kitchen. Made from high-quality wood, it provides a durable surface for all your chopping needs. Its natural finish highlights the beauty of the wood, making it a great addition to your kitchen decor.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullDescription",
                table: "Products");
        }
    }
}
