using WebApp.data;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using WebApp.data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();
// Thêm DbContext trực tiếp
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql("server=localhost;database=shoes_web;user=root;password=", 
        ServerVersion.AutoDetect("server=localhost;database=shoes_web;user=root;password=")));

builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddDistributedMemoryCache();

var app = builder.Build();

// Cấu hình pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "account",
    pattern: "login",
    defaults: new { controller = "Account", action = "Login" });
app.Run();
