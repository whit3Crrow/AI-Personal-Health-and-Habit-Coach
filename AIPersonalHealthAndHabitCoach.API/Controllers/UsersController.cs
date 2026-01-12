namespace AIPersonalHealthAndHabitCoach.API.Controllers
{
    public static class UsersController
    {
        public static void MapUsersEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/users")
                .WithTags("Users");

            group.MapPost("/", () => Results.Created());

            group.MapPut("/", () => Results.NoContent());

            group.MapGet("/", () => Results.Ok());
        }
    }
}