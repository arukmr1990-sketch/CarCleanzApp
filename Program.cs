using Microsoft.EntityFrameworkCore;
using CarCleanz.Data;

var builder = WebApplication.CreateBuilder(args);

// ? Add this (don’t remove connection string)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? "Data Source=CarCleanz.db";

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddControllersWithViews();

var app = builder.Build();

// ? Typical middleware setup
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();