using AIPersonalHealthAndHabitCoach.Application.Interfaces;
using AIPersonalHealthAndHabitCoach.Domain.Entities;
using AIPersonalHealthAndHabitCoach.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AIPersonalHealthAndHabitCoach.Application.Metrics.Queries.GetMetricById
{
    public class GetMetricByIdQueryHandler : IRequestHandler<GetMetricByIdQuery, Metric>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetMetricByIdQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Metric> Handle(GetMetricByIdQuery request, CancellationToken cancellationToken)
        {
            var metric = await _applicationDbContext.Metrics
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (metric is null)
            {
                throw new NotFoundException(nameof(Metric), request.Id.ToString());
            }

            return metric;
        }
    }
}