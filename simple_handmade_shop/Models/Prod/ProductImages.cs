namespace simple_handmade_shop.Models.Prod
{
    public class ProductImages
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public Product Product { get; set; } = null!;

    }
}
