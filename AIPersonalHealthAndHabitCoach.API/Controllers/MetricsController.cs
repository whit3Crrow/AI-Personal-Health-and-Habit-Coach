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
            group.MapPost("/activity", () => Results.Created());
            group.MapPost("/meal", () => Results.Created());

            group.MapPut("/sleep", async (UpdateSleepCommand command, IMediator mediator) =>
            {
                await mediator.Send(command);
                return Results.NoContent();
            });

            group.MapPut("/activity", () => Results.NoContent());
            group.MapPut("/meal", () => Results.NoContent());

            group.MapDelete("/{id}", (Guid id) => Results.NoContent());
        }
    }
}