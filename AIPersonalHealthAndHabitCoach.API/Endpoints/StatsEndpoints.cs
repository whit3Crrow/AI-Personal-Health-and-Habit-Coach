using AIPersonalHealthAndHabitCoach.Application.Stats.Queries.GetMetricByType;
using AIPersonalHealthAndHabitCoach.Application.Stats.Queries.GetMetricsSummary;
using AIPersonalHealthAndHabitCoach.Domain.Enums;
using MediatR;

namespace AIPersonalHealthAndHabitCoach.API.Endpoints
{
    public static class StatsEndpoints
    {
        public static void MapStatsEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/stats")
                .WithTags("Stats");

            group.MapGet("/metrics/summary", async ([AsParameters] GetMetricsSummaryQuery query, IMediator mediator) =>
            {
                var result = await mediator.Send(query);
                return Results.Ok(result);
            });

            group.MapGet("/metrics/{type}", async (MetricType type, [AsParameters] GetMetricByTypeQuery query, IMediator mediator) =>
            {
                if (type != query.Type)
                {
                    return Results.BadRequest();
                }

                var result = await mediator.Send(query);
                return Results.Ok(result);
            });
        }
    }
}