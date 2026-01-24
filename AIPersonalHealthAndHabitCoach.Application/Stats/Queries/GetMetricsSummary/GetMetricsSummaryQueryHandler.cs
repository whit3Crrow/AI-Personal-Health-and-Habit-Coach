using AIPersonalHealthAndHabitCoach.Application.Interfaces;
using AIPersonalHealthAndHabitCoach.Domain.Dtos;
using MediatR;

namespace AIPersonalHealthAndHabitCoach.Application.Stats.Queries.GetMetricsSummary
{
    public class GetMetricsSummaryQueryHandler : IRequestHandler<GetMetricsSummaryQuery, MetricStatsDto>
    {
        private readonly IMetricsStatsService _metricsStatsService;

        public GetMetricsSummaryQueryHandler(IMetricsStatsService metricsStatsService)
        {
            _metricsStatsService = metricsStatsService;
        }

        public async Task<MetricStatsDto> Handle(GetMetricsSummaryQuery request, CancellationToken cancellationToken)
        {
            return await _metricsStatsService.GetMetricsSummaryAsync(
                request.StartDate,
                request.EndDate,
                cancellationToken);
        }
    }
}