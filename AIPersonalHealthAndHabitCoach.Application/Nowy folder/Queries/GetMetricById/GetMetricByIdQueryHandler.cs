using AIPersonalHealthAndHabitCoach.Application.Interfaces;
using AIPersonalHealthAndHabitCoach.Domain.Entities; // Jeśli tu są Twoje encje
using AIPersonalHealthAndHabitCoach.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AIPersonalHealthAndHabitCoach.Application.Metrics.Queries.GetMetricById
{
    public class GetMetricByIdQueryHandler : IRequestHandler<GetMetricByIdQuery, object>
    {
        private readonly IApplicationDbContext _context;

        public GetMetricByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<object> Handle(GetMetricByIdQuery request, CancellationToken cancellationToken)
        {
            var sleep = await _context.Sleeps
                .AsNoTracking() 
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (sleep != null)
            {
                return sleep;
            }

            var activity = await _context.Activities
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (activity != null)
            {
                return activity;
            }

            var meal = await _context.Meals
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (meal != null)
            {
                return meal;
            }

            throw new NotFoundException("Metric", request.Id.ToString());
        }
    }
}