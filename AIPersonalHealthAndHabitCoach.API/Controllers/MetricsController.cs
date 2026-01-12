namespace AIPersonalHealthAndHabitCoach.API.Controllers
{
    public static class MetricsController
    {
        public static void MapMetricsEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/metrics");

            group.MapGet("/", () => Results.Ok());
            group.MapGet("/{id}", (Guid id) => Results.Ok());

            group.MapPost("/sleep", () => Results.Created());
            group.MapPost("/activity", () => Results.Created());
            group.MapPost("/meal", () => Results.Created());

            group.MapPut("/sleep", () => Results.NoContent());
            group.MapPut("/activity", () => Results.NoContent());
            group.MapPut("/meal", () => Results.NoContent());

            group.MapDelete("/{id}", (Guid id) => Results.NoContent());
        }
    }
}