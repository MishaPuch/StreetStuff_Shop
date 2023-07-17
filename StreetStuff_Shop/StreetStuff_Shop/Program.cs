using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using NUnit.Framework;
using StreetStuff_Shop;
using StreetStuff_Shop.BLL.DI;
using StreetStuff_Shop.BLL.Interfaces;
using StreetStuff_Shop.DAL.RepositoriumsInterface;
using StreetStuff_Shop.DAL.RepositoriumsService;
using StreetStuff_Shop.DI;
using StreetStuff_Shop.Interfaces;
using StreetStuff_Shop.Models;

var builder = WebApplication.CreateBuilder(args);

var AppConfig = builder.Configuration;

IConfigurationSection configuration = AppConfig.GetSection("ConnectionStrings");
string connectionString = configuration.GetSection("Data").Value;


// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddTransient<IDbContext , StreetStuff_Shop.DI.DbContext>(ConnectionString);
builder.Services.AddTransient<IRepositoryLiked, RepositoryLiked>();
builder.Services.AddTransient<IRepositoryUsers, RepositoryUser>();
builder.Services.AddTransient<IRepositoryCarts, RepositoryCarts>();
builder.Services.AddTransient<IRepositoryProducts, RepositoryProducts>();

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<ICartServicecs, CartServicecs>();
builder.Services.AddTransient<ILikedService, LikedService>();

builder.Services.AddTransient<ISessionService, SessionService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddDbContext<StreetStuffContext>(options => options.UseSqlServer(connectionString));





builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // время жизни сессии
});
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider
        .GetRequiredService<StreetStuffContext>();

    dbContext.Database.Migrate();
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
