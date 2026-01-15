using AIPersonalHealthAndHabitCoach.Application.Interfaces;
using MediatR;

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
            // TYMCZASOWY DEBUG
            Console.WriteLine($"---> DEBUG: Otrzymane ID: {request.Id}");
            Console.WriteLine($"---> DEBUG: Otrzymane Duration: {request.DurationMinutes}");
            var sleep = await _applicationDbContext.Sleeps
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (sleep == null)
            {
                throw new KeyNotFoundException($"Sleep record with ID {request.Id} not found.");
            }

            sleep.DurationMinutes = request.DurationMinutes;
            sleep.SleepQuality = request.SleepQuality; 
            sleep.StartDateTimeUtc = request.StartDate;

            await _applicationDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}