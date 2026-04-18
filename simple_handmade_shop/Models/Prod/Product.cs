namespace simple_handmade_shop.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string FullDescription { get; set; } = string.Empty;

        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
