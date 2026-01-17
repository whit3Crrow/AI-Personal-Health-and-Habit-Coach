using AIPersonalHealthAndHabitCoach.Application.Interfaces;
using AIPersonalHealthAndHabitCoach.Domain.Entities;
using AIPersonalHealthAndHabitCoach.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AIPersonalHealthAndHabitCoach.Application.Metrics.Commands.DeleteMetricById
{
    public class DeleteMetricByIdCommandHandler : IRequestHandler<DeleteMetricByIdCommand>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public DeleteMetricByIdCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task Handle(DeleteMetricByIdCommand request, CancellationToken cancellationToken)
        {
            var metric = await _applicationDbContext.Metrics
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (metric is null)
            {
                throw new NotFoundException(nameof(Metric), request.Id.ToString());
            }

            _applicationDbContext.Metrics.Remove(metric);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}