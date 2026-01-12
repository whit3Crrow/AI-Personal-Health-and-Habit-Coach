using AIPersonalHealthAndHabitCoach.API;
using AIPersonalHealthAndHabitCoach.Application.Extensions;
using AIPersonalHealthAndHabitCoach.Infrastructure.Extensions;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.MapApiEndpoints();

app.Run();
