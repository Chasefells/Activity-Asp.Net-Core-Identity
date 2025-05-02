using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ScaffoldIdentity.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ScaffoldIdentityConnection") ?? throw new InvalidOperationException("Connection string 'ScaffoldIdentityConnection' not found.");;

builder.Services.AddDbContext<ScaffoldIdentity>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ScaffoldIdentity>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();//added

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

var endpoints = app.Services.GetRequiredService<EndpointRouteBuilder>();

endpoints.MapRazorPages();//addd

app.Run();
//Which services are enabled?
//AddControllersWithViews(): This adds support for MVC controllers and views to the application.

//Which endpoints are enabled?
//MapControllerRoute(): This maps a route for MVC controllers, specifically the "default" route, which matches the pattern {controller=Home}/{action=Index}/{id?}.

//Which packages were installed for the basic web application?
//Microsoft.AspNetCore.Mvc: This package provides support for MVC controllers and views.
//Microsoft.AspNetCore.StaticFiles: This package provides support for serving static files.