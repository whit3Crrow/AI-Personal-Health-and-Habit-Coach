using AIPersonalHealthAndHabitCoach.Application.Interfaces;
using AIPersonalHealthAndHabitCoach.Domain.Entities;
using MediatR;

namespace AIPersonalHealthAndHabitCoach.Application.Sleeps.Commands.CreateSleep
{
    public class CreateSleepCommandHandler : IRequestHandler<CreateSleepCommand, Guid>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public CreateSleepCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Guid> Handle(CreateSleepCommand request, CancellationToken cancellationToken)
        {
            var sleep = new Sleep
            {
                Id = Guid.CreateVersion7(),
                DurationMinutes = request.DurationMinutes,
                SleepQuality = request.SleepQuality,
                StartDateTimeUtc = request.StartDate
            };

            _applicationDbContext.Sleeps.Add(sleep);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return sleep.Id;
        }
    }
}
