using AIPersonalHealthAndHabitCoach.Application.Stats.Queries.GetMetricByType;
using AIPersonalHealthAndHabitCoach.Application.Stats.Queries.GetMetricsSummary;
using AIPersonalHealthAndHabitCoach.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AIPersonalHealthAndHabitCoach.API.Endpoints
{
    public static class StatsEndpoints
    {
        public static void MapStatsEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/stats")
                .WithTags("Stats");

            group.MapGet("/metrics/summary", async (IMediator mediator, DateTime from, DateTime to) =>
            {
                var result = await mediator.Send(new GetMetricsSummaryQuery(from, to));
                return Results.Ok(result);
            });

            group.MapGet("/metrics/{type}", async (MetricType type, IMediator mediator, DateTime from, DateTime to) =>
            {
                var result = await mediator.Send(new GetMetricByTypeQuery(from, to, type));
                return Results.Ok(result);
            });
        }
    }
}