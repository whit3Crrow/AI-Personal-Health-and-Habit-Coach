using AIPersonalHealthAndHabitCoach.Application.Activities.Commands.CreateActivity;
using AIPersonalHealthAndHabitCoach.Application.Activities.Commands.UpdateActivity;
using AIPersonalHealthAndHabitCoach.Application.Meals.Commands.CreateMeal;
using AIPersonalHealthAndHabitCoach.Application.Meals.Commands.UpdateMeal;
using AIPersonalHealthAndHabitCoach.Application.Metrics.Queries.GetMetricById;
using AIPersonalHealthAndHabitCoach.Application.Metrics.Queries.GetMetrics;
using AIPersonalHealthAndHabitCoach.Application.Sleeps.Commands.CreateSleep;
using AIPersonalHealthAndHabitCoach.Application.Sleeps.Commands.UpdateSleep;
using AIPersonalHealthAndHabitCoach.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AIPersonalHealthAndHabitCoach.API.Endpoints
{
    public static class MetricsEndpoints
    {
        public static void MapMetricsEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/metrics")
                .WithTags("Metrics");

            group.MapGet("/", async (IMediator mediator, int page = 1, int pageSize = 5, [FromQuery] MetricType[]? metricTypes = null) => 
            {
                var result = await mediator.Send(new GetMetricsQuery(page, pageSize, metricTypes ?? []));
                return Results.Ok(result);
            });

            group.MapGet("/{id}", async (Guid id, IMediator mediator) =>
            {
                var result = await mediator.Send(new GetMetricByIdQuery(id));
                return Results.Ok(result);
            });

            group.MapPost("/sleep", async (CreateSleepCommand command, IMediator mediator) =>
            {
                var sleepId = await mediator.Send(command);
                return Results.Created($"api/metrics/sleep/{sleepId}", sleepId);
            });

            group.MapPost("/activity", async (CreateActivityCommand command, IMediator mediator) =>
            {
                var activityId = await mediator.Send(command);
                return Results.Created($"api/metrics/activity/{activityId}", activityId);
            });

            group.MapPost("/meal", async (CreateMealCommand command, IMediator mediator) =>
            {
                var mealId = await mediator.Send(command);
                return Results.Created($"api/metrics/meal/{mealId}", mealId);
            });

            group.MapPut("/sleep", async (UpdateSleepCommand command, IMediator mediator) =>
            {
                await mediator.Send(command);
                return Results.NoContent();
            });

            group.MapPut("/activity", async (UpdateActivityCommand command, IMediator mediator) =>
            {
                await mediator.Send(command);
                return Results.NoContent();
            });

            group.MapPut("/meal", async (UpdateMealCommand command, IMediator mediator) =>
            {
                await mediator.Send(command);
                return Results.NoContent();
            });

            group.MapDelete("/{id}", (Guid id) => Results.NoContent());
        }
    }
}
