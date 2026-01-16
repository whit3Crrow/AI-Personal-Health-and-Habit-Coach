using AIPersonalHealthAndHabitCoach.Application.Activities.Commands.CreateActivity;
using AIPersonalHealthAndHabitCoach.Application.Activities.Commands.UpdateActivity;
using AIPersonalHealthAndHabitCoach.Application.Meal.Commands.UpdateMeal;
using AIPersonalHealthAndHabitCoach.Application.Meals.Commands.CreateMeal;
using AIPersonalHealthAndHabitCoach.Application.Sleeps.Commands.CreateSleep;
using MediatR;

namespace AIPersonalHealthAndHabitCoach.API.Controllers
{
    public static class MetricsController
    {
        public static void MapMetricsEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/metrics")
                .WithTags("Metrics");

            group.MapGet("/", () => Results.Ok());
            group.MapGet("/{id}", (Guid id) => Results.Ok());

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

            // --- UPDATE (PUT) ---

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