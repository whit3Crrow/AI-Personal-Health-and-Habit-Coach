namespace AIPersonalHealthAndHabitCoach.API.Endpoints
{
    public static class AIEndpoints
    {
        public static void MapAIEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/ai")
                .WithTags("AI");

            group.MapGet("/metrics/analyze", () => Results.Ok());
        }
    }
}