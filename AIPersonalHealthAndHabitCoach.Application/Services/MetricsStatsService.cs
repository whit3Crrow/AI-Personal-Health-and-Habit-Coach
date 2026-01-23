using AIPersonalHealthAndHabitCoach.Application.Interfaces;
using AIPersonalHealthAndHabitCoach.Domain.Dtos;
using AIPersonalHealthAndHabitCoach.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace AIPersonalHealthAndHabitCoach.Application.Services
{
    public class MetricsStatsService : IMetricsStatsService
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public MetricsStatsService(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<MetricStatsDto> GetMetricByTypeAsync(DateTime startDate, DateTime endDate, MetricType metricType, CancellationToken cancellationToken)
        {
            return metricType switch
            {
                MetricType.Sleep => await GetSleepStatsAsync(startDate, endDate, cancellationToken),
                MetricType.Activity => await GetActivityStatsAsync(startDate, endDate, cancellationToken),
                MetricType.Meal => await GetMealStatsAsync(startDate, endDate, cancellationToken),
                _ => new MetricStatsDto()
            };
        }

        public async Task<MetricStatsDto> GetMetricsSummaryAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken)
        {
            var sleepStats = await GetSleepStatsAsync(startDate, endDate, cancellationToken);
            var activityStats = await GetActivityStatsAsync(startDate, endDate, cancellationToken);
            var mealStats = await GetMealStatsAsync(startDate, endDate, cancellationToken);

            return new MetricStatsDto
            {
                AverageSleepDurationMinutesPerDay = sleepStats.AverageSleepDurationMinutesPerDay,
                MostPopularSleepQuality = sleepStats.MostPopularSleepQuality,
                AverageCaloriesBurnedPerDay = activityStats.AverageCaloriesBurnedPerDay,
                MostPopularActivityType = activityStats.MostPopularActivityType,
                AverageProteinGramsPerDay = mealStats.AverageProteinGramsPerDay,
                AverageCarbonGramsPerDay = mealStats.AverageCarbonGramsPerDay,
                AverageFatGramsPerDay = mealStats.AverageFatGramsPerDay
            };
        }

        private async Task<MetricStatsDto> GetSleepStatsAsync(DateTime start, DateTime end, CancellationToken cancellationToken)
        {
            var dailyDurationMinutes = await _applicationDbContext.Sleeps
                .Where(x => x.StartDateTimeUtc >= start && x.StartDateTimeUtc < end)
                .GroupBy(x => x.StartDateTimeUtc.Date)
                .Select(g => g.Sum(x => x.DurationMinutes))
                .ToListAsync(cancellationToken);

            var mostPopularSleepQuality = await _applicationDbContext.Sleeps
                .Where(x => x.StartDateTimeUtc >= start && x.StartDateTimeUtc < end)
                .GroupBy(x => x.SleepQuality)
                .OrderByDescending(g => g.Count())
                .Select(g => (SleepQuality?)g.Key)
                .FirstOrDefaultAsync(cancellationToken);

            return new MetricStatsDto
            {
                AverageSleepDurationMinutesPerDay = dailyDurationMinutes.Count != 0 ? (decimal?)dailyDurationMinutes.Average() : 0,
                MostPopularSleepQuality = mostPopularSleepQuality
            };
        }

        private async Task<MetricStatsDto> GetActivityStatsAsync(DateTime start, DateTime end, CancellationToken cancellationToken)
        {
            var dailyCaloriesBurned = await _applicationDbContext.Activities
                .Where(x => x.StartDateTimeUtc >= start && x.StartDateTimeUtc < end)
                .GroupBy(x => x.StartDateTimeUtc.Date)
                .Select(g => g.Sum(x => x.CaloriesBurned))
                .ToListAsync(cancellationToken);

            var mostPopularActivityType = await _applicationDbContext.Activities
                .Where(x => x.StartDateTimeUtc >= start && x.StartDateTimeUtc < end)
                .GroupBy(x => x.ActivityType)
                .OrderByDescending(g => g.Count())
                .Select(g => (ActivityType?)g.Key)
                .FirstOrDefaultAsync(cancellationToken);

            return new MetricStatsDto
            {
                AverageCaloriesBurnedPerDay = dailyCaloriesBurned.Count != 0 ? (decimal?)dailyCaloriesBurned.Average() : 0,
                MostPopularActivityType = mostPopularActivityType
            };
        }

        private async Task<MetricStatsDto> GetMealStatsAsync(DateTime start, DateTime end, CancellationToken cancellationToken)
        {
            var dailyMacros = await _applicationDbContext.Meals
                .Where(x => x.StartDateTimeUtc >= start && x.StartDateTimeUtc < end)
                .GroupBy(x => x.StartDateTimeUtc.Date)
                .Select(g => new
                {
                    Protein = g.Sum(x => x.ProteinGrams),
                    Carbon = g.Sum(x => x.CarbonGrams),
                    Fat = g.Sum(x => x.FatGrams)
                })
                .ToListAsync(cancellationToken);

            if (dailyMacros.Count == 0)
            {
                return new MetricStatsDto
                {
                    AverageProteinGramsPerDay = 0,
                    AverageCarbonGramsPerDay = 0,
                    AverageFatGramsPerDay = 0
                };
            }

            return new MetricStatsDto
            {
                AverageProteinGramsPerDay = dailyMacros.Average(x => x.Protein),
                AverageCarbonGramsPerDay = dailyMacros.Average(x => x.Carbon),
                AverageFatGramsPerDay = dailyMacros.Average(x => x.Fat)
            };
        }
    }
}