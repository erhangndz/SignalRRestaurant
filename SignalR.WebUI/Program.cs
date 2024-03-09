using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.CodeAnalysis.FlowAnalysis;
using Microsoft.EntityFrameworkCore;
using SignalR.DataAccess.Concrete;
using SignalR.Entity.Entities;
using SignalR.WebUI.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddDbContext<SignalRContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<SignalRContext>();
builder.Services.AddControllersWithViews(cfg =>
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    cfg.Filters.Add(new AuthorizeFilter(policy));

    
});
builder.Services.ConfigureApplicationCookie(_ =>
{
    _.LoginPath = new PathString("/Login/Index");
    _.AccessDeniedPath = new PathString("/ErrorPage/AccessDenied/");
    _.LogoutPath = new PathString("/Login/Logout");


});

builder.Services.AddAuthorization(opt =>
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    opt.AddPolicy("", policy);
    
    
});
builder.Services.AddAuthentication(options =>
{
    options.RequireAuthenticatedSignIn = true;
    

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
