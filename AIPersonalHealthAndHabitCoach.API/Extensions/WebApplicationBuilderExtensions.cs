using AIPersonalHealthAndHabitCoach.API.Middlewares;

namespace AIPersonalHealthAndHabitCoach.API.Extensions
{
    public static class WebApplicationBuilderExtensions
    {
        public static void AddPresentation(this WebApplicationBuilder builder)
        {
            builder.Services.AddOpenApi();

            builder.Services.AddTransient<ErrorHandlingMiddleware>();
        }
    }
}