using AIPersonalHealthAndHabitCoach.Domain.Dtos;
using AIPersonalHealthAndHabitCoach.Domain.Enums;

namespace AIPersonalHealthAndHabitCoach.Application.Interfaces
{
    public interface IMetricsStatsService
    {
        Task<MetricStatsDto> GetMetricByTypeAsync(DateTime startDate, DateTime endDate, MetricType metricType, CancellationToken cancellationToken);
        Task<MetricStatsDto> GetMetricsSummaryAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken);
    }
}
