using Microsoft.EntityFrameworkCore;
using StoreApp.Data.Abstract;
using StoreApp.Data.Concrete;
using StoreApp.Web.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("StoreDbConnection");

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);

builder.Services.AddDbContext<StoreDbContext>(options => {
    options.UseSqlite(connectionString, b => b.MigrationsAssembly("StoreApp.Web"));
});

builder.Services.AddScoped<IStoreRepository, EfStoreRepository>();

var app = builder.Build();

app.UseStaticFiles();

// products/phone => products of category list
app.MapControllerRoute("products_in_category", "products/{category}", new { controller = "Home", action = "Index" });

// iphone-14 => product detail
app.MapControllerRoute("product_details", "{productName}", new { controller = "Home", action = "Index" });

app.MapDefaultControllerRoute();
app.MapRazorPages();
app.Run();