using AIPersonalHealthAndHabitCoach.API.Endpoints;

namespace AIPersonalHealthAndHabitCoach.API
{
    public static class EndpointDefinitions
    {
        public static void MapApiEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapAIEndpoints();
            app.MapMetricsEndpoints();
            app.MapStatsEndpoints();
            app.MapUsersEndpoints();
        }
    }
}