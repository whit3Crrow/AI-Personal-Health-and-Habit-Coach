using AIPersonalHealthAndHabitCoach.Application.Interfaces;
using AIPersonalHealthAndHabitCoach.Domain.Entities; 
using AIPersonalHealthAndHabitCoach.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore; 

namespace AIPersonalHealthAndHabitCoach.Application.Sleeps.Commands.UpdateSleep
{
    public class UpdateSleepCommandHandler : IRequestHandler<UpdateSleepCommand>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public UpdateSleepCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task Handle(UpdateSleepCommand request, CancellationToken cancellationToken)
        {
            var sleep = await _applicationDbContext.Sleeps
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (sleep == null)
            {
                throw new NotFoundException(nameof(Sleep), request.Id.ToString());
            }

            sleep.DurationMinutes = request.DurationMinutes;
            sleep.SleepQuality = request.SleepQuality;
            sleep.StartDateTimeUtc = request.StartDate;

            await _applicationDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}