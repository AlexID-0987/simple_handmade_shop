using Microsoft.AspNetCore.Identity;
using simple_handmade_shop.Models.Interfaces;

public class DbInitialiserRole : IAdmin
{
    private readonly IConfiguration _configuration;

    public DbInitialiserRole(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task CreateAdmin(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        string adminEmail = _configuration["Admin:Email"];
        string adminPassword = _configuration["Admin:Password"];

        // Створити роль якщо немає
        if (!await roleManager.RoleExistsAsync("Admin"))
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));
        }

        // Перевірити чи існує користувач
        var user = await userManager.FindByEmailAsync(adminEmail);

        if (user == null)
        {
            user = new IdentityUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(user, adminPassword);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "Admin");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    Console.WriteLine(error.Description);
                }
            }
        }
    }
}