namespace AIPersonalHealthAndHabitCoach.API.Controllers
{
    public static class AIController
    {
        public static void MapAIEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/ai");

            group.MapGet("/metrics/analyze", () =>
            {
                return Results.Ok();
            });
        }
    }
}