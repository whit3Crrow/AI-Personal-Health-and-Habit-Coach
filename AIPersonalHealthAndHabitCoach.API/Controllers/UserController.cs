using AIPersonalHealthAndHabitCoach.Domain.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;

namespace AIPersonalHealthAndHabitCoach.API.Controllers
{
    public static class UserController
    {
        public static void MapUserEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/user");

            group.MapPost("/", (UserData user) => Results.Ok("Utworzono użytkownika"));

            group.MapPut("/", (UserData user) => Results.Ok("Zaktualizowano dane użytkownika"));

            group.MapGet("/{id:guid}", (Guid id) =>
            {
                // Zwracamy mocka (przykładowe dane)
                return Results.Ok(new UserData { Id = id, Age = 25, WeightKilograms = 70 });
            });
        }
    }
}