using AIPersonalHealthAndHabitCoach.Domain.Dtos;
using AIPersonalHealthAndHabitCoach.Domain.Enums;
using MediatR;

namespace AIPersonalHealthAndHabitCoach.Application.Stats.Queries.GetMetricByType
{
    public class GetMetricByTypeQuery : IRequest<MetricStatsDto>
    {
        public required DateTime StartDate { get; set; }
        public required DateTime EndDate { get; set; }
        public required MetricType Type { get; set; }
    }
}