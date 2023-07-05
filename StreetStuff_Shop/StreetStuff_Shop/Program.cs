using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using NUnit.Framework;
using StreetStuff_Shop;
using StreetStuff_Shop.DAL;
using StreetStuff_Shop.DI;
using StreetStuff_Shop.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var AppConfig = builder.Configuration;

IConfigurationSection configuration = AppConfig.GetSection("ConnectionStrings");
string connectionString = configuration.GetSection("Data").Value;


// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddTransient<IDbContext , StreetStuff_Shop.DI.DbContext>(ConnectionString);
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddDbContext<StreetStuffContext>(options => options.UseSqlServer(connectionString));



builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // время жизни сессии
});
var app = builder.Build();

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
