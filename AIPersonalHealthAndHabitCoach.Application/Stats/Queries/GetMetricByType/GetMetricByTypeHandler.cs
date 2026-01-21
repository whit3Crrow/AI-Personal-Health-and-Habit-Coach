using AIPersonalHealthAndHabitCoach.Application.Interfaces;
using AIPersonalHealthAndHabitCoach.Domain.Dtos;
using MediatR;

namespace AIPersonalHealthAndHabitCoach.Application.Stats.Queries.GetMetricByType
{
    public class GetMetricByTypeHandler : IRequestHandler<GetMetricByTypeQuery, MetricStatsDto>
    {
        private readonly IMetricsStatsService _metricsStatsService;

        public GetMetricByTypeHandler(IMetricsStatsService metricsStatsService)
        {
            _metricsStatsService = metricsStatsService;
        }

        public async Task<MetricStatsDto> Handle(GetMetricByTypeQuery request, CancellationToken cancellationToken)
        {
            return await _metricsStatsService.GetMetricByType(
                request.StartDate,
                request.EndDate,
                request.MetricType,
                cancellationToken);
        }
    }
}