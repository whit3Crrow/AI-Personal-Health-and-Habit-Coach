using AIPersonalHealthAndHabitCoach.Application.Interfaces;
using MediatR;

namespace AIPersonalHealthAndHabitCoach.Application.AI.Queries
{
    public class GetMetricsAnalyzeQueryHandler : IRequestHandler<GetMetricsAnalyzeQuery, string>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMetricsStatsService _metricsStatsService;

        public GetMetricsAnalyzeQueryHandler(IApplicationDbContext applicationDbContext, IMetricsStatsService metricsStatsService)
        {
            _applicationDbContext = applicationDbContext;
            _metricsStatsService = metricsStatsService;
        }

        public async Task<string> Handle(GetMetricsAnalyzeQuery request, CancellationToken cancellationToken)
        {
            return string.Empty;
        }
    }
}
