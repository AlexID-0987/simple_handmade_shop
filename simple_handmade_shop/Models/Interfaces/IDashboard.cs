using Microsoft.AspNetCore.Identity;
using simple_handmade_shop.Data;
using simple_handmade_shop.Models.Admin;
using simple_handmade_shop.Models.Orderproducts;

namespace simple_handmade_shop.Models.Interfaces
{
    public interface IDashboard
    {
        AdminDashboard GetUsers();
        IEnumerable<OrderItem> GetOrders(int id);
    }
}
