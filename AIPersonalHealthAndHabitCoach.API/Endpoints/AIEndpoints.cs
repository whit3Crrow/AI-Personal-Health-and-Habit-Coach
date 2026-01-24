using AIPersonalHealthAndHabitCoach.Application.AI.Queries;
using MediatR;

namespace AIPersonalHealthAndHabitCoach.API.Endpoints
{
    public static class AIEndpoints
    {
        public static void MapAIEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/ai")
                .WithTags("AI");

            group.MapGet("/metrics/analyze", async ([AsParameters] GetMetricsAnalyzeQuery query, IMediator mediator) =>
            {
                var result = await mediator.Send(query);
                return Results.Ok(result);
            });
        }
    }
}