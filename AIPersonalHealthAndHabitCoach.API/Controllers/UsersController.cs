using AIPersonalHealthAndHabitCoach.Application.Users.Commands.CreateUser;
using MediatR;

namespace AIPersonalHealthAndHabitCoach.API.Controllers
{
    public static class UsersController
    {
        public static void MapUsersEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/users")
                .WithTags("Users");

            group.MapPost("/", async (CreateUserCommand command, IMediator mediator) =>
            {
                var userId = await mediator.Send(command);

                return Results.Created($"/users/{userId}", userId);
            });

            group.MapPut("/", () => Results.NoContent());

            group.MapGet("/", () => Results.Ok());
        }
    }
}