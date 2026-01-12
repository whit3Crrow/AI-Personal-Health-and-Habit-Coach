using AIPersonalHealthAndHabitCoach.Application.Users.Commands.CreateUser;
using AIPersonalHealthAndHabitCoach.Application.Users.Commands.UpdateUser;
using AIPersonalHealthAndHabitCoach.Application.Users.Queries.GetUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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

            group.MapPut("/", async ([FromBody] UpdateUserCommand command, IMediator mediator) =>
            {
                await mediator.Send(command);

                return Results.NoContent();
            });

            group.MapGet("/", async (IMediator mediator) =>
            {
                var query = new GetUserQuery();
                var result = await mediator.Send(query);

                return Results.Ok(result);
            });
        }
    }
}