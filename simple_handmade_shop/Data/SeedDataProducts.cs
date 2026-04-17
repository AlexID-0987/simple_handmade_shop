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
                    Price = 149.99m,
                    ImageUrl = "/photo/Без названия.jpg"
                },
                new Product
                {
                    Id = 2,
                    Name = "Handmade",
                    Description = "An elegant ceramic vase with intricate designs, perfect for home decor.",
                    Price = 79.99m,
                    ImageUrl = "/photo/lav.jpg"
                },
                new Product
                {
                    Id = 3,
                    Name = "Handmade Leather Wallet",
                    Description = "A stylish and durable leather wallet that combines functionality with craftsmanship.",
                    Price = 59.99m,
                    ImageUrl = "/photo/lavanda.jpg"
                },
                new Product
                {
                    Id = 4,
                    Name = "Handmade soap",
                    Description = "A cozy and fashionable knitted scarf made from soft yarn, ideal for chilly days.",
                    Price = 39.99m,
                    ImageUrl = "/photo/lavandawood.jpg"
                },
                new Product
                {
                    Id = 5,
                    Name = "Lavanda",
                    Description = "A sturdy and attractive wooden cutting board that adds a rustic touch to your kitchen.",
                    Price = 29.99m,
                    ImageUrl = "/photo/Без названия.jpg"
                }
            );
        }
    }
}
