using Microsoft.EntityFrameworkCore;
using AspCoreWebAppMVC.Data;
using AspCoreWebAppMVC.Repositories.Implementation;
using AspCoreWebAppMVC.Repositories.Interfaces;
using AspCoreWebAppMVC.Utility;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DevelopmentDB"));
});
builder.Services.AddScoped<IUser, UserRepository>();
builder.Services.AddScoped<IUserUtility, UserUtilityRepository>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=AllUserList}/{id?}");

app.Run();
