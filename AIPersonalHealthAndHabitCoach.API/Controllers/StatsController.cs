using AIPersonalHealthAndHabitCoach.Domain.Enums;

namespace AIPersonalHealthAndHabitCoach.API.Controllers
{
    public static class StatsController
    {
        public static void MapStatsEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/stats");

            group.MapGet("/metrics/summary", () => Results.Ok());

            group.MapGet("/metrics/{type}", (MetricType type) => Results.Ok());
        }
    }
}