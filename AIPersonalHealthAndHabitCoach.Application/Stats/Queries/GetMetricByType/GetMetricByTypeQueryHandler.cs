using AIPersonalHealthAndHabitCoach.Application.Interfaces;
using AIPersonalHealthAndHabitCoach.Domain.Dtos;
using MediatR;

namespace AIPersonalHealthAndHabitCoach.Application.Stats.Queries.GetMetricByType
{
    public class GetMetricByTypeQueryHandler : IRequestHandler<GetMetricByTypeQuery, MetricStatsDto>
    {
        private readonly IMetricsStatsService _metricsStatsService;

        public GetMetricByTypeQueryHandler(IMetricsStatsService metricsStatsService)
        {
            _metricsStatsService = metricsStatsService;
        }

        public async Task<MetricStatsDto> Handle(GetMetricByTypeQuery request, CancellationToken cancellationToken)
        {
            return await _metricsStatsService.GetMetricByTypeAsync(
                request.StartDate,
                request.EndDate,
                request.Type,
                cancellationToken);
        }
    }
}