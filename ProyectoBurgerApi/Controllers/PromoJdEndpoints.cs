using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ProyectoBurgerApi.Data;
using ProyectoBurgerApi.Data.Models;
namespace ProyectoBurgerApi.Controllers;

public static class PromoJdEndpoints
{
    public static void MapPromoJdEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/PromoJd").WithTags(nameof(Promo_JDS));

        group.MapGet("/", async (ProyectoBurgerApiContext db) =>
        {
            return await db.Promo_JDS.ToListAsync();
        })
        .WithName("GetAllPromoJds")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Promo_JDS>, NotFound>> (int promoidjds, ProyectoBurgerApiContext db) =>
        {
            return await db.Promo_JDS.AsNoTracking()
                .FirstOrDefaultAsync(model => model.PromoId_JDS == promoidjds)
                is Promo_JDS model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetPromoJdById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int promoidjds, Promo_JDS promoJd, ProyectoBurgerApiContext db) =>
        {
            var affected = await db.Promo_JDS
                .Where(model => model.PromoId_JDS == promoidjds)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.PromoId_JDS, promoJd.PromoId_JDS)
                    .SetProperty(m => m.BurgerId_JDS, promoJd.BurgerId_JDS)
                    .SetProperty(m => m.FechaPromo_JDS, promoJd.FechaPromo_JDS)
                    .SetProperty(m => m.BurgerId_JDS, promoJd.BurgerId_JDS)
                    .SetProperty(m => m.Burger_JDS, promoJd.Burger_JDS)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdatePromoJd")
        .WithOpenApi();

        group.MapPost("/", async (Promo_JDS promoJd, ProyectoBurgerApiContext db) =>
        {
            db.Promo_JDS.Add(promoJd);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/PromoJd/{promoJd.PromoId_JDS}", promoJd);
        })
        .WithName("CreatePromoJd")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int promoidjds, ProyectoBurgerApiContext db) =>
        {
            var affected = await db.Promo_JDS
                .Where(model => model.PromoId_JDS == promoidjds)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeletePromoJd")
        .WithOpenApi();
    }
}
