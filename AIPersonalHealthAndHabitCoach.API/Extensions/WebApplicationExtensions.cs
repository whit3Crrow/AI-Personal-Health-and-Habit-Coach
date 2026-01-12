using AIPersonalHealthAndHabitCoach.API.Middlewares;

namespace AIPersonalHealthAndHabitCoach.API.Extensions
{
    public static class WebApplicationExtensions
    {
        public static void ApplyMiddlewares(this WebApplication app)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}
