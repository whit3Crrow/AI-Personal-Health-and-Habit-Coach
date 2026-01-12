using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;

namespace AIPersonalHealthAndHabitCoach.API.Controllers
{
    public static class StatsController
    {
        public static void MapStatsEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/stats");

            group.MapGet("/summary/{userId:guid}", (Guid userId) =>
            {
                return Results.Ok("Tu będzie podsumowanie statystyk");
            });

            group.MapGet("/type/{userId:guid}", (Guid userId, string type) =>
            {
                return Results.Ok($"Szczegółowe statystyki dla: {type}");
            });
        }
    }
}