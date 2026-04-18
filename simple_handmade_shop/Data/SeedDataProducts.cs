using Microsoft.EntityFrameworkCore;
using simple_handmade_shop.Models;


namespace simple_handmade_shop.Data
{
    public static class SeedDataProducts
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Lavander Sache",
                    Description = "A beautifully crafted wooden chair made from high-quality materials.",
                    FullDescription = "This handmade wooden chair is a perfect blend of craftsmanship and comfort. Made from high-quality wood, it features a sturdy frame and a comfortable seat. The intricate design adds a touch of elegance to any room, making it a great addition to your home decor.",
                    Price = 149.99m,
                    ImageUrl = "/photo/Без названия.jpg"
                },
                new Product
                {
                    Id = 2,
                    Name = "Handmade",
                    Description = "An elegant ceramic vase with intricate designs, perfect for home decor.",
                    FullDescription = "This elegant ceramic vase is a true work of art, featuring intricate designs that showcase the skill of the artisan. Its unique shape and beautiful glaze make it a stunning centerpiece for any room.",         
                    Price = 79.99m,
                    ImageUrl = "/photo/lav.jpg"
                },
                new Product
                {
                    Id = 3,
                    Name = "Handmade Leather Wallet",
                    Description = "A stylish and durable leather wallet that combines functionality with craftsmanship.",
                    FullDescription =" This handmade leather wallet is crafted from high-quality leather, ensuring durability and a timeless look. It features multiple compartments for cards, cash, and coins, making it both practical and stylish. The attention to detail in the stitching and design reflects the skill of the artisan, making it a perfect accessory for everyday use.",
                    Price = 59.99m,
                    ImageUrl = "/photo/lavanda.jpg"
                },
                new Product
                {
                    Id = 4,
                    Name = "Handmade soap",
                    Description = "A cozy and fashionable knitted scarf made from soft yarn, ideal for chilly days.",
                    FullDescription = "This cozy knitted scarf is made from soft, high-quality yarn, providing warmth and comfort during chilly days. Its fashionable design makes it a versatile accessory that can be worn in various styles, adding a touch of elegance to any outfit.",
                    Price = 39.99m,
                    ImageUrl = "/photo/lavandawood.jpg"
                },
                new Product
                {
                    Id = 5,
                    Name = "Lavanda",
                    Description = "A sturdy and attractive wooden cutting board that adds a rustic touch to your kitchen.",
                    FullDescription = "This sturdy wooden cutting board is not only functional but also adds a rustic touch to your kitchen. Made from high-quality wood, it provides a durable surface for all your chopping needs. Its natural finish highlights the beauty of the wood, making it a great addition to your kitchen decor.",
                    Price = 29.99m,
                    ImageUrl = "/photo/Без названия.jpg"
                }
            );
        }
    }
}
