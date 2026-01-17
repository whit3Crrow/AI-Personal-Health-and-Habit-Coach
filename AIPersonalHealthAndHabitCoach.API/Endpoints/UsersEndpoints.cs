using AIPersonalHealthAndHabitCoach.Application.Users.Commands.CreateUser;
using AIPersonalHealthAndHabitCoach.Application.Users.Commands.UpdateUser;
using AIPersonalHealthAndHabitCoach.Application.Users.Queries.GetUser;
using MediatR;

namespace AIPersonalHealthAndHabitCoach.API.Endpoints
{
    public static class UsersEndpoints
    {
        public static void MapUsersEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/users")
                .WithTags("Users");

            group.MapPost("/", async (CreateUserCommand command, IMediator mediator) =>
            {
                var userId = await mediator.Send(command);
                return Results.Created($"api/users/{userId}", userId);
            });

            group.MapPut("/", async (UpdateUserCommand command, IMediator mediator) =>
            {
                await mediator.Send(command);
                return Results.NoContent();
            });

            group.MapGet("/", async (IMediator mediator) =>
            {
                var result = await mediator.Send(new GetUserQuery());
                return Results.Ok(result);
            });
        }
    }
}