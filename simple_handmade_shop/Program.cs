using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using simple_handmade_shop.Data;

using simple_handmade_shop.Models.Interfaces;
using simple_handmade_shop.Models.Orderproducts;
using simple_handmade_shop.Models.Services;

var builder = WebApplication.CreateBuilder(args);

// Connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// Database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Identity + Roles
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;

    // Password settings
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;
})
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<ApplicationDbContext>();

// MVC
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Cache + HttpContext
builder.Services.AddDistributedMemoryCache();
builder.Services.AddHttpContextAccessor();

// Custom Services
builder.Services.AddScoped<IGetProducts, HelperWithProducts>();
builder.Services.AddScoped<IGetBag, HelperWithBags>();
builder.Services.AddScoped<IGetOrder, OrderChoice>();
builder.Services.AddScoped<SendEmailService>();
builder.Services.AddScoped<IGenerateDocument, SendDocument>();
builder.Services.AddScoped<IHelperAdmin, HelperwithAdmin>();

// Admin Initializer
builder.Services.AddScoped<IAdmin, DbInitialiserRole>();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Create Admin + Role automatically
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    var adminInitializer = services.GetRequiredService<IAdmin>();

    await adminInitializer.CreateAdmin(userManager, roleManager);
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseSession();

// Routes
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();