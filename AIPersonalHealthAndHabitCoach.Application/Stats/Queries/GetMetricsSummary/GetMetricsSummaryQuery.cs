using AIPersonalHealthAndHabitCoach.Domain.Dtos;
using MediatR;

namespace AIPersonalHealthAndHabitCoach.Application.Stats.Queries.GetMetricsSummary
{
    public class GetMetricsSummaryQuery : IRequest<MetricStatsDto>
    {
        public required DateTime StartDate { get; set; }
        public required DateTime EndDate { get; set; }
    }
}