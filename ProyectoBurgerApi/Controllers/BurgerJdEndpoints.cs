using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using ProyectoBurgerApi.Data;
using ProyectoBurgerApi.Data.Models;
namespace ProyectoBurgerApi.Controllers;

public static class BurgerJdEndpoints
{
    public static void MapBurgerJdEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/BurgerJd").WithTags(nameof(Burger_JDS));

        group.MapGet("/", async (ProyectoBurgerApiContext db) =>
        {
            return await db.Burger_JDS.ToListAsync();
        })
        .WithName("GetAllBurgerJds")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Burger_JDS>, NotFound>> (int burgeridjds, ProyectoBurgerApiContext db) =>
        {
            return await db.Burger_JDS.AsNoTracking()
                .FirstOrDefaultAsync(model => model.BurgerId_JDS == burgeridjds)
                is Burger_JDS model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetBurgerJdById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int burgeridjds, Burger_JDS burgerJd, ProyectoBurgerApiContext db) =>
        {
            var affected = await db.Burger_JDS
                .Where(model => model.BurgerId_JDS == burgeridjds)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.BurgerId_JDS, burgerJd.BurgerId_JDS)
                    .SetProperty(m => m.Name_JDS, burgerJd.Name_JDS)
                    .SetProperty(m => m.WithCheese_JDS, burgerJd.WithCheese_JDS)
                    .SetProperty(m => m.Precio_JDS, burgerJd.Precio_JDS)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateBurgerJd")
        .WithOpenApi();

        group.MapPost("/", async (Burger_JDS burgerJd, ProyectoBurgerApiContext db) =>
        {
            db.Burger_JDS.Add(burgerJd);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/BurgerJd/{burgerJd.BurgerId_JDS}",burgerJd);
        })
        .WithName("CreateBurgerJd")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int burgeridjds, ProyectoBurgerApiContext db) =>
        {
            var affected = await db.Burger_JDS
                .Where(model => model.BurgerId_JDS == burgeridjds)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteBurgerJd")
        .WithOpenApi();
    }
}
