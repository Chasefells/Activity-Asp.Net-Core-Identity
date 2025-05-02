using ScaffoldIdentity.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Routing;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("ScaffoldIdentityConnection") ?? throw new InvalidOperationException("Connection string 'ScaffoldIdentityConnection' not found.");

builder.Services.AddDbContext<ScaffoldIdentityDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ScaffoldIdentityDbContext>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapRazorPages();

app.Run();
//Which services are enabled?
//AddControllersWithViews(): This adds support for MVC controllers and views to the application.

//Which endpoints are enabled?
//MapControllerRoute(): This maps a route for MVC controllers, specifically the "default" route, which matches the pattern {controller=Home}/{action=Index}/{id?}.

//Which packages were installed for the basic web application?
//Microsoft.AspNetCore.Mvc: This package provides support for MVC controllers and views.
//Microsoft.AspNetCore.StaticFiles: This package provides support for serving static files.