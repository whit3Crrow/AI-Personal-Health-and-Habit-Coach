using AIPersonalHealthAndHabitCoach.Domain.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;

namespace AIPersonalHealthAndHabitCoach.API.Controllers
{
    public static class MetricsController
    {
        public static void MapMetricsEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/metrics");

            // GET
            group.MapGet("/", () => Results.Ok("Pobrano wszystkie metryki"));
            group.MapGet("/{id:guid}", (Guid id) => Results.Ok($"Pobrano metrykę {id}"));

            // POST (Create)
            group.MapPost("/sleep", (Sleep sleep) => Results.Ok("Dodano sen"));
            group.MapPost("/activity", (Activity activity) => Results.Ok("Dodano aktywność"));
            group.MapPost("/meal", (Meal meal) => Results.Ok("Dodano posiłek"));

            // PUT (Update)
            group.MapPut("/sleep", (Sleep sleep) => Results.Ok("Zaktualizowano sen"));
            group.MapPut("/activity", (Activity activity) => Results.Ok("Zaktualizowano aktywność"));
            group.MapPut("/meal", (Meal meal) => Results.Ok("Zaktualizowano posiłek"));

            // DELETE
            group.MapDelete("/{id:guid}", (Guid id) => Results.Ok($"Usunięto element {id}"));
        }
    }
}