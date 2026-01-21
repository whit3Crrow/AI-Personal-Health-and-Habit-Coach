using AIPersonalHealthAndHabitCoach.Domain.Dtos;
using MediatR;

namespace AIPersonalHealthAndHabitCoach.Application.Stats.Queries.GetMetricsSummary
{
    public class GetMetricsSummaryQuery : MetricStatsSummaryQueryDto, IRequest<MetricStatsDto>
    {
        public GetMetricsSummaryQuery(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}