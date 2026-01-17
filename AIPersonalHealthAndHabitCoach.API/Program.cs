using AIPersonalHealthAndHabitCoach.API;
using AIPersonalHealthAndHabitCoach.API.Extensions;
using AIPersonalHealthAndHabitCoach.Application.Extensions;
using AIPersonalHealthAndHabitCoach.Infrastructure.Extensions;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);
builder.AddPresentation();
builder.Services.AddApplication();

var app = builder.Build();

app.ApplyMiddlewares();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.MapApiEndpoints();

app.Run();
