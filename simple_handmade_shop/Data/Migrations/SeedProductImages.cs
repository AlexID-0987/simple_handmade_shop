using Microsoft.EntityFrameworkCore;
using simple_handmade_shop.Models.Prod;

namespace simple_handmade_shop.Data.Migrations
{
    public static class SeedProductImages
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductImages>().HasData(
                new ProductImages
                {
                    Id = 1,
                    ProductId = 1,
                    ImageUrl = "/photo/Без названия.jpg"
                },
                new ProductImages
                {
                    Id = 2,
                    ProductId = 1,
                    ImageUrl = "/photo/lav.jpg"
                },
                new ProductImages
                {
                    Id = 3,
                    ProductId = 1,
                    ImageUrl = "/photo/lavanda.jpg"
                },
                new ProductImages
                {
                    Id = 4,
                    ProductId = 2,
                    ImageUrl = "/photo/lavandawood.jpg"
                },
                new ProductImages
                {
                    Id = 5,
                    ProductId = 2,
                    ImageUrl = "/photo/Без названия.jpg"
                },
                new ProductImages
                {
                    Id = 6,
                    ProductId = 2,
                    ImageUrl = "/photo/lav.jpg"
                },
                new ProductImages
                {
                    Id = 7,
                    ProductId = 3,
                    ImageUrl = "/photo/lavanda.jpg"
                },
                new ProductImages
                {
                    Id = 8,
                    ProductId = 3,
                    ImageUrl = "/photo/lavandawood.jpg"
                },
                new ProductImages
                {
                    Id = 9,
                    ProductId = 4,
                    ImageUrl = "/photo/lav.jpg"
                },
                new ProductImages
                {
                    Id = 10,
                    ProductId = 4,
                    ImageUrl = "/photo/lavanda.jpg"
                },
                new ProductImages
                {
                    Id = 11,
                    ProductId = 4,
                    ImageUrl = "/photo/lavandawood.jpg"
                },
                new ProductImages
                {
                    Id = 12,
                    ProductId = 5,
                    ImageUrl = "/photo/lav.jpg"
                },
                new ProductImages
                {
                    Id = 13,
                    ProductId = 5,
                    ImageUrl = "/photo/lavanda.jpg"
                },
                new ProductImages
                {
                    Id = 14,
                    ProductId = 5,
                    ImageUrl = "/photo/lavandawood.jpg"
                }
            );
        }
    }
}
