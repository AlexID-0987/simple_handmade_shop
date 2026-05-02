using Microsoft.AspNetCore.Identity;

namespace simple_handmade_shop.Models.Interfaces
{
    public interface IAdmin
    {
        public  Task CreateAdmin(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager);
    }
}
