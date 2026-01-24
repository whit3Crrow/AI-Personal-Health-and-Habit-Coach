using AIPersonalHealthAndHabitCoach.Application.Behaviors;
using AIPersonalHealthAndHabitCoach.Application.Interfaces;
using AIPersonalHealthAndHabitCoach.Application.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace AIPersonalHealthAndHabitCoach.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var applicationAssembly = typeof(ServiceCollectionExtensions).Assembly;

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(applicationAssembly);
                cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });

            services.AddValidatorsFromAssembly(applicationAssembly);

            services.AddScoped<IMetricsStatsService, MetricsStatsService>();
        }
    }
}