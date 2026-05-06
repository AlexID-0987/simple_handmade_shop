using Microsoft.AspNetCore.Identity;
using simple_handmade_shop.Data;
using simple_handmade_shop.Models.Admin;

namespace simple_handmade_shop.Models.Interfaces
{
    public interface IDashboard
    {
        AdminDashboard GetUsers();
    }
}
