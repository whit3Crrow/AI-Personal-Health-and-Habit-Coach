using AIPersonalHealthAndHabitCoach.API;
using AIPersonalHealthAndHabitCoach.Application.Extensions;
using AIPersonalHealthAndHabitCoach.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddInfrastructure();
builder.Services.AddApplication();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapApiEndpoints();

app.Run();
