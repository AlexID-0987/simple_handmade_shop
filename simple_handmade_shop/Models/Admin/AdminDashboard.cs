using Microsoft.AspNetCore.Identity;
using simple_handmade_shop.Models.Orderproducts;

namespace simple_handmade_shop.Models.Admin
{
    public class AdminDashboard
    {
        public List<IdentityUser> Users { get; set; }
        public List<Order> Orders { get; set; }
    }
}
