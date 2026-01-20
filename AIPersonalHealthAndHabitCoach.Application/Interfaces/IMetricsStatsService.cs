using AIPersonalHealthAndHabitCoach.Domain.Dtos;
using AIPersonalHealthAndHabitCoach.Domain.Enums;

namespace AIPersonalHealthAndHabitCoach.Application.Interfaces
{
    public interface IMetricsStatsService
    {
        Task<MetricStatsDto> GetMetricByType(DateTime startDate, DateTime endDate, MetricType metricType, CancellationToken cancellationToken);
        Task<MetricStatsDto> GetMetricsSummary(DateTime startDate, DateTime endDate, CancellationToken cancellationToken);
    }
}
