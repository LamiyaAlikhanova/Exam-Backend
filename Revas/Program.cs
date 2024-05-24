using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Revas.DAL;
using Revas.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(opt =>
{
	opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
builder.Services.AddIdentity<User,IdentityRole>(opt=>
{
   
}

).AddEntityFrameworkStores<AppDbContext>();

var app = builder.Build();
 app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();


app.UseAuthorization();
app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
          );

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
