using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace AIPersonalHealthAndHabitCoach.API.Controllers
{
    public static class AIController
    {
        public static void MapAIEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/ai");

            group.MapGet("analyze", () =>
            {
                return Results.Ok("Tu będzie analiza AI Twoich nawyków.");
            });
        }
    }
}