using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProyectoBurger_MVC_API_MAUI.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ProyectoBurger_MVC_API_MAUIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProyectoBurger_MVC_API_MAUIContext") ?? throw new InvalidOperationException("Connection string 'ProyectoBurger_MVC_API_MAUIContext' not found.")));

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
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home_JDS}/{action=Index_JDS}/{id?}");

app.Run();
