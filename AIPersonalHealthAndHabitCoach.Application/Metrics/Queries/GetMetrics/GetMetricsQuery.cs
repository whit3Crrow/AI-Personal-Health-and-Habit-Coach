using AIPersonalHealthAndHabitCoach.Domain.Common;
using AIPersonalHealthAndHabitCoach.Domain.Entities;
using AIPersonalHealthAndHabitCoach.Domain.Enums;
using MediatR;

namespace AIPersonalHealthAndHabitCoach.Application.Metrics.Queries.GetMetrics
{
    public class GetMetricsQuery : IRequest<PagedResult<Metric>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public MetricType[] MetricTypes { get; set; } = [];

        public GetMetricsQuery(int page, int pageSize, MetricType[] metricTypes)
        {
            Page = page;
            PageSize = pageSize;
            MetricTypes = metricTypes;
        }
    }
}