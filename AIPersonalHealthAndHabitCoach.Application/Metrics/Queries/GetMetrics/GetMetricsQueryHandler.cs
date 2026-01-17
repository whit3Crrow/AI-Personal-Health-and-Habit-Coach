using AIPersonalHealthAndHabitCoach.Application.Extensions;
using AIPersonalHealthAndHabitCoach.Application.Interfaces;
using AIPersonalHealthAndHabitCoach.Domain.Common;
using AIPersonalHealthAndHabitCoach.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AIPersonalHealthAndHabitCoach.Application.Metrics.Queries.GetMetrics
{
    public class GetMetricsQueryHandler : IRequestHandler<GetMetricsQuery, PagedResult<Metric>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetMetricsQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<PagedResult<Metric>> Handle(GetMetricsQuery request, CancellationToken cancellationToken)
        {
            var metrics = await _applicationDbContext.Metrics
                .AsNoTracking()
                .Where(x => request.MetricTypes.Count() == 0 || request.MetricTypes.Contains(x.Type))
                .GetPagedAsync(request.Page, request.PageSize, cancellationToken);

            return metrics;
        }
    }
}