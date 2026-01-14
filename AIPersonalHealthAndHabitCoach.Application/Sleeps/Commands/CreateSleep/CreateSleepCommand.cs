using AIPersonalHealthAndHabitCoach.Domain.Enums;
using MediatR;

namespace AIPersonalHealthAndHabitCoach.Application.Sleeps.Commands.CreateSleep
{
    public class CreateSleepCommand : IRequest<Guid>
    {
        public required int DurationMinutes { get; set; }
        public required SleepQuality SleepQuality { get; set; }
        public required DateTime StartDate { get; set; }
    }
}
