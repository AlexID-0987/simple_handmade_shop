using Microsoft.AspNetCore.Identity;

namespace simple_handmade_shop.Models.Orderproducts
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        public string? UserId { get; set; }
        public IdentityUser? User { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public int Quantity { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
