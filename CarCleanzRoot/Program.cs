using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CarCleanz.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// ✅ Enables session storage for login tracking
builder.Services.AddSession();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("CarCleanzDB"));


var app = builder.Build();

// Middleware order is important!
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// ✅ Activates session for all requests
app.UseSession();

// Authorization (if needed later)
app.UseAuthorization();

// Default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
