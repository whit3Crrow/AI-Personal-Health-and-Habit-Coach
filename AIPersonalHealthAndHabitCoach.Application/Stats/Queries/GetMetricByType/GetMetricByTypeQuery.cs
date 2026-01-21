using AIPersonalHealthAndHabitCoach.Domain.Dtos;
using AIPersonalHealthAndHabitCoach.Domain.Enums;
using MediatR;

namespace AIPersonalHealthAndHabitCoach.Application.Stats.Queries.GetMetricByType
{
    public class GetMetricByTypeQuery : MetricStatsTypeQueryDto, IRequest<MetricStatsDto>
    {
        public GetMetricByTypeQuery(DateTime startDate, DateTime endDate, MetricType metricType)
        {
            StartDate = startDate;
            EndDate = endDate;
            MetricType = metricType;
        }
    }
}