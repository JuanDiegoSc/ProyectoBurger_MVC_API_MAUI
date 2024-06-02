using Microsoft.EntityFrameworkCore;
using ProyectoBurgerApi.Controllers;
using ProyectoBurgerApi.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ProyectoBurgerApiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProyectoBurgerApiContext") ?? throw new InvalidOperationException("Connection string 'ProyectoBurgerApiContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapPromoJdEndpoints();

app.MapBurgerJdEndpoints();

app.Run();

