using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using simple_handmade_shop.Data;
using simple_handmade_shop.Models.Admin;
using simple_handmade_shop.Models.Interfaces;
using simple_handmade_shop.Models.Orderproducts;

namespace simple_handmade_shop.Models.Services
{
    public class HelperDashboard: IDashboard
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public HelperDashboard(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public AdminDashboard GetUsers()
        {
            AdminDashboard users = new AdminDashboard()
            {
                Users = _userManager.Users.ToList(),
                Orders = _context.Orders
                .Include(o => o.User)
                .OrderByDescending(o => o.OrderDate)
                .ToList()
            };
            return users;
        }
        public IEnumerable<OrderItem> GetOrders(int id)
        {
            var orderItems = _context.OrderItems
                   .Where(oi => oi.OrderId == id)
                   .Include(oi => oi.Product)
                   .ToList();
            return orderItems;
        }
    }
}
